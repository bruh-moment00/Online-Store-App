using Online_Store_Backend.Domain.Categories.Dto;

namespace Online_Store_Backend.Domain.Categories.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDto> GetById(long id);
        Task<List<CategoryDto>> GetAll();
        Task<long> InsertCategory(CategoryDto category);
        Task<bool> UpdateCategory(CategoryDto category);
        Task<bool> DeleteCategory(long id);
    }
}
