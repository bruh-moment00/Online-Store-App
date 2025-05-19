using Online_Store_Backend.Core.Data.Repository;
using Online_Store_Backend.Database.Products.Models;
using Online_Store_Backend.Domain.Products.Dto;
using Online_Store_Backend.Domain.Products.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Backend.Domain.Products.Services
{
    public class ProductImageService : IProductImageService
    {
        private readonly IRepositoryAsync<ProductImage> productImageRepository;
        public ProductImageService(IRepositoryAsync<ProductImage> productImageRepository) => this.productImageRepository = productImageRepository;
        public async Task<ProductImageDto> GetById(long imageId)
        {
            var entity = await this.productImageRepository.FindById(imageId);
            return entity == null ? null : MapEntityToDto(entity);
        }
        public async Task<List<ProductImageDto>> GetAll()
        {
            var entities = await this.productImageRepository.Filter(x => !x.IsDeleted);
            return entities.Select(MapEntityToDto).ToList();
        }
        public async Task<List<ProductImageDto>> GetByProductId(long productId)
        {
            var entities = await this.productImageRepository.Filter(x => x.ProductID == productId && !x.IsDeleted);
            return entities.Select(MapEntityToDto).ToList();
        }
        public async Task<long> InsertProductImage(ProductImageDto productImage)
        {
            var entity = MapDtoToEntity(productImage);
            return await this.productImageRepository.Insert(entity);
        }
        public async Task<bool> UpdateProductImage(ProductImageDto productImage)
        {
            var entity = MapDtoToEntity(productImage);
            return await this.productImageRepository.Update(entity) != 0;
        }
        public async Task<bool> DeleteProductImage(long id) => await this.productImageRepository.Delete(id);
        private static ProductImageDto MapEntityToDto(ProductImage productImage)
        {
            return new ProductImageDto
            {
                ID = productImage.ID,
                CreatedDateTime = productImage.CreatedDateTime,
                IsActive = productImage.IsActive,
                IsDeleted = productImage.IsDeleted,
                ImageAddress = productImage.ImageAddress,
                ProductID = productImage.ProductID,
            };
        }
        private static ProductImage MapDtoToEntity(ProductImageDto productImage)
        {
            return new ProductImage
            {
                ID = productImage.ID,
                ImageAddress = productImage.ImageAddress,
                ProductID = productImage.ProductID,
            };
        }
    }
}
