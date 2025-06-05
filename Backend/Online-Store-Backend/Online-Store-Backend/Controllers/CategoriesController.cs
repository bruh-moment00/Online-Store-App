using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Store_Backend.Domain.Categories.Dto;
using Online_Store_Backend.Domain.Categories.Services.Interfaces;

namespace Online_Store_Backend.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(long id)
        {
            var category = await categoryService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await categoryService.GetAll();
            return Ok(categories);
        }

        [Authorize(Roles = "employee")]
        [HttpPost]
        public async Task<ActionResult<long>> InsertCategory([FromBody] CategoryDto category)
        {
            if (category == null)
            {
                return BadRequest("Category cannot be null");
            }
            var categoryId = await categoryService.InsertCategory(category);
            return categoryId > 0 ? Ok(categoryId) : BadRequest("Failed to insert category");
        }

        [Authorize(Roles = "employee")]
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> UpdateCategory(long id, [FromBody] CategoryDto category)
        {
            if (category == null || category.ID != id)
            {
                return BadRequest("Category data is invalid");
            }
            var result = await categoryService.UpdateCategory(category);
            return result ? Ok(result) : NotFound("Category not found or update failed");
        }

        [Authorize(Roles = "employee")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteCategory(long id)
        {
            var result = await categoryService.DeleteCategory(id);
            return result ? Ok(result) : NotFound("Category not found or delete failed");
        }
    }
}
