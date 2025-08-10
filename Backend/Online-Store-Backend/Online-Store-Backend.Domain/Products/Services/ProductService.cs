using Online_Store_Backend.Domain.Products.Dto;
using Online_Store_Backend.Core.Data.Repository;
using Online_Store_Backend.Database.Products.Models;
using Online_Store_Backend.Domain.Products.Services.Interfaces;
using Online_Store_Backend.Domain.Pagination;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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

        public async Task<PaginationDto<ProductDto>> GetProducts(IGetProductsParams @params)
        {
            var entities = await this.productRepository.Filter(x => !x.IsDeleted); 
            if (@params.CategoryId.HasValue)
            {
                entities = entities.Where(e => e.CategoryID == @params.CategoryId);
            }

            if (@params.Search != null)
            {
                entities = entities.Where(e => e.Name.Contains(@params.Search, StringComparison.OrdinalIgnoreCase));
            }

            switch (@params.SortColumn)
            {
                case Enums.SortColumnProduct.Name:
                    if (@params.SortOrder == SortOrder.Ascending)
                        entities = entities.OrderBy(e => e.Name);
                    else
                        entities = entities.OrderByDescending(e => e.Name);
                    break;

                case Enums.SortColumnProduct.Price:
                    if (@params.SortOrder == SortOrder.Ascending)
                        entities = entities.OrderBy(e => e.Price);
                    else
                        entities = entities.OrderByDescending(e => e.Price);
                    break;
            }

            PaginationEntity<Product> paginatedProducts = new PaginationEntity<Product>(entities, @params.PageNumber, @params.PageSize);
            return new PaginationDto<ProductDto>(paginatedProducts.Items.Select(MapEntityToDto).ToList(), 
                                                 paginatedProducts.TotalCount,
                                                 paginatedProducts.PageNumber,
                                                 paginatedProducts.PageSize,
                                                 paginatedProducts.TotalPages);
        }

        public async Task<long> InsertProduct(ProductDto product)
        {
            var entity = MapDtoToEntity(product);
            return await this.productRepository.Insert(entity);
        }

        public async Task<bool> UpdateProduct(ProductDto product)
        {
            var entity = MapDtoToEntity(product);
            return await this.productRepository.Update(entity) != 0;
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
