using Online_Store_Backend.Domain.Categories.Dto;

namespace Online_Store_Backend.Domain.Categories.Services.Interfaces
{
    public interface IPropertyService
    {
        Task<PropertyDto> GetById(long id);
        Task<List<PropertyDto>> GetProperties(long? categoryId = null);
        Task<long> InsertProperty(PropertyDto property);
        Task<bool> UpdateProperty(PropertyDto property);
        Task<bool> DeleteProperty(long id);
    }
}
