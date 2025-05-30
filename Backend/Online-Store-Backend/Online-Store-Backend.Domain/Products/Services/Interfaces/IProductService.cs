using Online_Store_Backend.Domain.Pagination;
using Online_Store_Backend.Domain.Products.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Backend.Domain.Products.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> GetById(long id);
        Task<PaginationDto<ProductDto>> GetProducts(long? categoryId = null, int pageNumber = 1, int pageSize = 10);
        Task<long> InsertProduct(ProductDto product);
        Task<bool> UpdateProduct(ProductDto product);
        Task<bool> DeleteProduct(long id);
    }
}
