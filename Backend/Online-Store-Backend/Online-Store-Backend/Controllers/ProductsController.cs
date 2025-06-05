using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Store_Backend.Domain.Products.Dto;
using Online_Store_Backend.Domain.Products.Services.Interfaces;

namespace Online_Store_Backend.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(long id)
        {
            var product = await productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetProducts(long? categoryId = null, int page = 1, int size = 10)
        {
            var products = await productService.GetProducts(categoryId, page, size);
            return Ok(products);
        }

        [Authorize(Roles = "employee")]
        [HttpPost]
        public async Task<ActionResult<long>> InsertProduct([FromBody] ProductDto product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null");
            }
            var productId = await productService.InsertProduct(product);
            return productId > 0 ? Ok(productId) : BadRequest("Failed to insert product");
        }

        [Authorize(Roles = "employee")]
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> UpdateProduct(long id, [FromBody] ProductDto product)
        {
            if (product == null || product.ID != id)
            {
                return BadRequest("Product data is invalid");
            }
            var result = await productService.UpdateProduct(product);
            return result ? Ok(result) : NotFound("Product not found or update failed");
        }

        [Authorize(Roles = "employee")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            var result = await productService.DeleteProduct(id);
            if (result)
            {
                return Ok("Product deleted successfully");
            }
            return NotFound("Product not found or delete failed");
        }
    }
}
