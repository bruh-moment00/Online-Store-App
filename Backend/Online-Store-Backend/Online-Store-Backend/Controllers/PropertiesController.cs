using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_Store_Backend.Domain.Categories.Dto;
using Online_Store_Backend.Domain.Categories.Services.Interfaces;
using Online_Store_Backend.Domain.Categories.Views;

namespace Online_Store_Backend.Controllers
{
    [Route("api/properties")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyService propertyService;
        private readonly IProductPropValueService productPropValueService;
        public PropertiesController(IPropertyService propertyService, IProductPropValueService productPropValueService)
        {
            this.propertyService = propertyService;
            this.productPropValueService = productPropValueService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetProperties(long? categoryId = null)
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

        [Route("values")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetPropertyValuesByProductId(long? productId = null)
        {
            var propertyValues = await productPropValueService.GetProductPropValues(productId);
            if (propertyValues == null)
            {
                return NotFound();
            }
            return Ok(propertyValues);
        }

        [Route("values/{id}")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetPropertyValue(long id)
        {
            var propertyValue = await productPropValueService.GetById(id);
            if (propertyValue == null)
            {
                return NotFound();
            }
            return Ok(propertyValue);
        }

        [Route("values")]
        [Authorize(Roles = "employee")]
        [HttpPost]
        public async Task<ActionResult<long>> InsertPropertyValue([FromBody] ProductPropValueDto productPropValue)
        {
            if (productPropValue == null)
            {
                return BadRequest("Product property value cannot be null");
            }
            var propertyValueId = await productPropValueService.InsertProductPropValue(productPropValue);
            return propertyValueId > 0 ? Ok(propertyValueId) : BadRequest("Failed to insert product property value");
        }

        [Route("values/{id}")]
        [Authorize(Roles = "employee")]
        [HttpPut]
        public async Task<ActionResult<bool>> UpdatePropertyValue([FromBody] ProductPropValueDto productPropValue)
        {
            if (productPropValue == null)
            {
                return BadRequest("Product property value data is invalid");
            }
            var result = await productPropValueService.UpdateProductPropValue(productPropValue);
            return result ? Ok(result) : NotFound("Product property value not found or update failed");
        }

        [Route("values/{id}")]
        [Authorize(Roles = "employee")]
        [HttpDelete]
        public async Task<IActionResult> DeletePropertyValue(long id)
        {
            var result = await productPropValueService.DeleteProductPropValue(id);
            return result ? Ok(result) : NotFound("Product property value not found or delete failed");
        }

        [Route("view")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetPropertiesViewByProductId(long productId)
        {
            var propertyValues = await productPropValueService.GetProductPropValues(productId);
            if (propertyValues == null || !propertyValues.Any())
            {
                return NotFound("No property values found for the specified product.");
            }
            var result = new List<PropertyView>();
            foreach (var value in propertyValues)
            {
                var property = await propertyService.GetById(value.PropID);
                if (property != null)
                {
                    var view = new PropertyView
                    {
                        PropertyId = value.PropID,
                        Name = property.PropName,
                        ValueId = value.ID,
                        Value = value.Value,
                        ValueType = property.ValueType
                    };
                    result.Add(view);
                }
            }
            return Ok(result);
        }
    }
}
