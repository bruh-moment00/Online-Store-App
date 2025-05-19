using Online_Store_Backend.Core.Data.Repository;
using Online_Store_Backend.Database.Categories.Models;
using Online_Store_Backend.Domain.Categories.Dto;
using Online_Store_Backend.Domain.Categories.Services.Interfaces;

namespace Online_Store_Backend.Domain.Categories.Services
{
    public class ProductPropValueService : IProductPropValueService
    {
        private readonly IRepositoryAsync<ProductPropValue> productPropValueRepository;
        public ProductPropValueService(IRepositoryAsync<ProductPropValue> productPropValueRepository) => this.productPropValueRepository = productPropValueRepository;
        public async Task<List<ProductPropValueDto>> GetByProductId(long productId)
        {
            var entities = await this.productPropValueRepository.Filter(x => x.ProductID == productId && !x.IsDeleted);
            return entities.Select(MapEntityToDto).ToList();
        }
        public async Task<long> InsertProductPropValue(ProductPropValueDto productPropValue)
        {
            var entity = MapDtoToEntity(productPropValue);
            return await this.productPropValueRepository.Insert(entity);
        }
        public async Task<bool> UpdateProductPropValue(ProductPropValueDto productPropValue)
        {
            var entity = MapDtoToEntity(productPropValue);
            return await this.productPropValueRepository.Update(entity) != 0;
        }
        public async Task<bool> DeleteProductPropValue(long id) => await this.productPropValueRepository.Delete(id);

        private static ProductPropValueDto MapEntityToDto(ProductPropValue productPropValue)
        {
            return new ProductPropValueDto
            {
                ID = productPropValue.ID,
                CreatedDateTime = productPropValue.CreatedDateTime,
                IsActive = productPropValue.IsActive,
                IsDeleted = productPropValue.IsDeleted,
                ProductID = productPropValue.ProductID,
                PropID = productPropValue.PropID,
                Value = productPropValue.Value
            };
        }
        private static ProductPropValue MapDtoToEntity(ProductPropValueDto productPropValue)
        {
            return new ProductPropValue
            {
                ID = productPropValue.ID,
                ProductID = productPropValue.ProductID,
                PropID = productPropValue.PropID,
                Value = productPropValue.Value
            };
        }
    }
}
