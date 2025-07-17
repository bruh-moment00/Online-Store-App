using Microsoft.AspNetCore.Authorization;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Online_Store_Backend.Domain.Products.Dto;
using Online_Store_Backend.Domain.Products.Services.Interfaces;
using static System.Net.Mime.MediaTypeNames;

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
        public async Task<IActionResult> UploadImage([FromBody] IFormFile image, long productID)
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
            string path = environment.WebRootPath + "\\images\\products\\" + productID;

            if (Directory.Exists(path))
            {
                IEnumerable<string> images = new List<string>();
                await Task.Run(() =>
                {
                    images = Directory.EnumerateFiles(path).Select(i =>
                    {
                        return $"images/products/{productID}/{Path.GetFileName(i)}";
                    })
                    .ToList();                   
                });
                return Ok(images);
            }

            return NotFound("No images found for this product");
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> RenameImage(string address, string newName)
        {
            string fileName = environment.WebRootPath + '\\' + address.Replace('/', '\\');
            if (System.IO.File.Exists(fileName))
            {
                bool resultOk = false;
                await Task.Run(() =>
                {
                    string? path = Path.GetDirectoryName(fileName);
                    string ext = Path.GetExtension(fileName);   
                    try
                    {
                        System.IO.File.Move(fileName, path + "\\" + newName + ext);
                        resultOk = true;
                    } 
                    catch (IOException ex)
                    {
                        resultOk = false;
                    }
                    
                });
                return resultOk ? Ok(true) : BadRequest("Cannot rename file");
                
            }
            return BadRequest("File not exist");
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteImage(string address)
        {
            string fileName = environment.WebRootPath + '\\' + address.Replace('/', '\\');
            if (System.IO.File.Exists(fileName))
            {
                await Task.Run(() =>
                {
                    System.IO.File.Delete(fileName);
                });
                return Ok(true);
            }

            return BadRequest("File not exist");
        }
    }
}
