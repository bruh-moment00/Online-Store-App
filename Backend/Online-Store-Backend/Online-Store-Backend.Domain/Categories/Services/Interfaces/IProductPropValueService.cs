using Online_Store_Backend.Domain.Categories.Dto;

namespace Online_Store_Backend.Domain.Categories.Services.Interfaces
{
    public interface IProductPropValueService
    {
        Task<ProductPropValueDto> GetById(long id);
        Task<List<ProductPropValueDto>> GetProductPropValues(long? productId = null);
        Task<long> InsertProductPropValue(ProductPropValueDto productPropValue);
        Task<bool> UpdateProductPropValue(ProductPropValueDto productPropValue);
        Task<bool> DeleteProductPropValue(long id);
    }
}
