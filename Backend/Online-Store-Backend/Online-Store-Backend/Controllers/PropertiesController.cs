using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Store_Backend.Domain.Categories.Dto;
using Online_Store_Backend.Domain.Categories.Services.Interfaces;

namespace Online_Store_Backend.Controllers
{
    [Route("api/properties")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyService propertyService;
        public PropertiesController(IPropertyService propertyService)
        {
            this.propertyService = propertyService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetPropertiesByCategoryId(long? categoryId = null)
        {
            var properties = await propertyService.GetProperties(categoryId);
            if (properties == null)
            {
                return NotFound();
            }
            return Ok(properties);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProperty(long id)
        {
            var property = await propertyService.GetById(id);
            if (property == null)
            {
                return NotFound();
            }
            return Ok(property);
        }

        [Authorize(Roles = "employee")]
        [HttpPost]
        public async Task<ActionResult<long>> InsertProperty([FromBody] PropertyDto property)
        {
            if (property == null)
            {
                return BadRequest("Property cannot be null");
            }
            var propertyId = await propertyService.InsertProperty(property);
            return propertyId > 0 ? Ok(propertyId) : BadRequest("Failed to insert property");
        }

        [Authorize(Roles = "employee")]
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> UpdateProperty([FromBody] PropertyDto property)
        {
            if (property == null)
            {
                return BadRequest("Property data is invalid");
            }
            var result = await propertyService.UpdateProperty(property);
            return result ? Ok(result) : NotFound("Property not found or update failed");
        }

        [Authorize(Roles = "employee")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(long id)
        {
            var result = await propertyService.DeleteProperty(id);
            return result ? Ok(result) : NotFound("Property not found or delete failed");
        }
    }
}
