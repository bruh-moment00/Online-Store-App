using Online_Store_Backend.Domain.Products.Dto;
using Online_Store_Backend.Core.Data.Repository;
using Online_Store_Backend.Database.Products.Models;
using Online_Store_Backend.Domain.Products.Services.Interfaces;

namespace Online_Store_Backend.Domain.Products.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryAsync<Product> productRepository;
        public ProductService(IRepositoryAsync<Product> productRepository) => this.productRepository = productRepository;
        public async Task<ProductDto> GetById(long id)
        {
            var entity = await this.productRepository.FindById(id);
            return entity == null ? null : MapEntityToDto(entity);
        }

        public async Task<List<ProductDto>> GetAll()
        {
            var entities = await this.productRepository.Filter(x => !x.IsDeleted);
            return entities.Select(MapEntityToDto).ToList();
        }

        public async Task<long> InsertProduct(ProductDto product)
        {
            var entity = MapDtoToEntity(product);
            return await this.productRepository.Insert(entity);
        }

        public async Task<ProductDto> UpdateProduct(ProductDto product)
        {
            var entity = MapDtoToEntity(product);
            await this.productRepository.Update(entity);
            return product;
        }

        public async Task<bool> DeleteProduct(long id) => await this.productRepository.Delete(id);
        private static ProductDto MapEntityToDto(Product product)
        {
            return new ProductDto
            {
                ID = product.ID,
                CreatedDateTime = product.CreatedDateTime,
                IsActive = product.IsActive,
                IsDeleted = product.IsDeleted,
                Name = product.Name,
                Description = product.Description,
                CategoryID = product.CategoryID,
                Price = product.Price,
            };
        }

        private static Product MapDtoToEntity(ProductDto product)
        {
            return new Product
            {
                ID = product.ID,
                Name = product.Name,
                Description = product.Description,
                CategoryID = product.CategoryID,
                Price = product.Price,
            };
        }
    }
}
