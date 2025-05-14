using Online_Store_Backend.Domain.Categories.Dto;

namespace Online_Store_Backend.Domain.Categories.Services.Interfaces
{
    public interface IPropertyService
    {
        Task<List<PropertyDto>> GetByCategoryId(long categoryId);
        Task<long> InsertProperty(PropertyDto property);
        Task<PropertyDto> UpdateProperty(PropertyDto property);
        Task<bool> DeleteProperty(long id);
    }
}
