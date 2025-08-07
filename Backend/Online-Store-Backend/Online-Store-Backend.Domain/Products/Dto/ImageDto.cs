using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Backend.Domain.Products.Dto
{
    public class ImageDto
    {
        public required long ProductId { get; set; }
        public required IFormFile File { get; set; }
    }
}
