using Online_Store_Backend.Core.Data.Repository;
using Online_Store_Backend.Database.Categories.Models;
using Online_Store_Backend.Domain.Categories.Dto;
using Online_Store_Backend.Domain.Categories.Services.Interfaces;

namespace Online_Store_Backend.Domain.Categories.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryAsync<Category> categoryRepository;
        public CategoryService(IRepositoryAsync<Category> categoryRepository) => this.categoryRepository = categoryRepository;
        public async Task<CategoryDto> GetById(long id)
        {
            var entity = await this.categoryRepository.FindById(id);
            return entity == null ? null : MapEntityToDto(entity);
        }
        public async Task<List<CategoryDto>> GetAll()
        {
            var entities = await this.categoryRepository.Filter(x => !x.IsDeleted);
            return entities.Select(MapEntityToDto).ToList();
        }
        public async Task<long> InsertCategory(CategoryDto category)
        {
            var entity = MapDtoToEntity(category);
            return await this.categoryRepository.Insert(entity);
        }
        public async Task<CategoryDto> UpdateCategory(CategoryDto category)
        {
            var entity = MapDtoToEntity(category);
            await this.categoryRepository.Update(entity);
            return category;
        }
        public async Task<bool> DeleteCategory(long id) => await this.categoryRepository.Delete(id);
        private static CategoryDto MapEntityToDto(Category category)
        {
            return new CategoryDto
            {
                ID = category.ID,
                CreatedDateTime = category.CreatedDateTime,
                IsActive = category.IsActive,
                IsDeleted = category.IsDeleted,
                Name = category.Name
            };
        }
        private static Category MapDtoToEntity(CategoryDto category)
        {
            return new Category
            {
                ID = category.ID,
                Name = category.Name
            };
        }
    }
}
