using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Online_Store_Backend.Domain.Products.Dto;
using Online_Store_Backend.Domain.Products.Services.Interfaces;

namespace Online_Store_Backend.Controllers
{
    [Route("api/products/images")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService productImageService;
        private readonly IWebHostEnvironment environment;
        public ProductImagesController(IProductImageService productImageService, IWebHostEnvironment environment)
        {
            this.productImageService = productImageService;
            this.environment = environment;
        }

        [Authorize(Roles = "employee")]
        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile image, long productID)
        {
            string path = environment.WebRootPath + "\\images\\products\\" + productID;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            using (FileStream fileStream = System.IO.File.Create($"{path}\\{image.FileName}"))
            {
                await image.CopyToAsync(fileStream);
                fileStream.Flush();
                ProductImageDto productImage = new ProductImageDto
                {
                    ImageAddress = $"images/products/{productID}/{image.FileName}",
                    ProductID = productID,
                };

                var imageId = await productImageService.InsertProductImage(productImage);
                return imageId >= 0 ? Ok(imageId) : BadRequest("Failed to upload image");
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetImagesByProductID(long productID)
        {
            var images = await productImageService.GetByProductId(productID);
            var paths = images.Select(i =>
            {
                return Url.Content(i.ImageAddress);
            }).ToList();

            return Ok(paths);
        }
    }
}
