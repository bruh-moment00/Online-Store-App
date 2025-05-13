using Online_Store_Backend.Domain.Products.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Backend.Domain.Products.Services.Interfaces
{
    public interface IProductImageService
    {
        Task<ProductImageDto> GetById(long imageId);
        Task<List<ProductImageDto>> GetAll();
        Task<List<ProductImageDto>> GetByProductId(long productId);
        Task<long> InsertProductImage(ProductImageDto productImage);
        Task<ProductImageDto> UpdateProductImage(ProductImageDto productImage);
        Task<bool> DeleteProductImage(long id);
    }
}
