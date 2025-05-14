using Online_Store_Backend.Domain.Categories.Dto;

namespace Online_Store_Backend.Domain.Categories.Services.Interfaces
{
    public interface IProductPropValueService
    {
        Task<List<ProductPropValueDto>> GetByProductId(long productId);
        Task<long> InsertProductPropValue(ProductPropValueDto productPropValue);
        Task<ProductPropValueDto> UpdateProductPropValue(ProductPropValueDto productPropValue);
        Task<bool> DeleteProductPropValue(long id);
    }
}
