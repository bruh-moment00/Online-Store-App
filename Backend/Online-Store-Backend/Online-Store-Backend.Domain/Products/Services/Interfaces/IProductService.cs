using Online_Store_Backend.Domain.Pagination;
using Online_Store_Backend.Domain.Products.Dto;

namespace Online_Store_Backend.Domain.Products.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> GetById(long id);
        Task<PaginationDto<ProductDto>> GetProducts(IGetProductsParams @params);
        Task<long> InsertProduct(ProductDto product);
        Task<bool> UpdateProduct(ProductDto product);
        Task<double> GetCostByIds(IEnumerable<long> productIds);
        Task<bool> DeleteProduct(long id);
    }
}
