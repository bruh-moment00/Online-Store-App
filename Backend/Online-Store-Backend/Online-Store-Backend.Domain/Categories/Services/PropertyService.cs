using Online_Store_Backend.Core.Data.Repository;
using Online_Store_Backend.Database.Categories.Models;
using Online_Store_Backend.Domain.Categories.Dto;
using Online_Store_Backend.Domain.Categories.Services.Interfaces;

namespace Online_Store_Backend.Domain.Categories.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IRepositoryAsync<Property> propertyRepository;
        public PropertyService(IRepositoryAsync<Property> propertyRepository) => this.propertyRepository = propertyRepository;
        public async Task<PropertyDto> GetById(long id)
        {
            var entity = await propertyRepository.FindById(id);
            return entity == null ? null : MapEntityToDto(entity);
        }
        public async Task<List<PropertyDto>> GetProperties(long? categoryId = null)
        {
            var entities = await this.propertyRepository.Filter(x => !x.IsDeleted);
            if (categoryId.HasValue)
            {
                entities = entities.Where(c => c.CategoryID == categoryId);
            }
            return entities.Select(MapEntityToDto).ToList();
        }
        public async Task<long> InsertProperty(PropertyDto property)
        {
            var entity = MapDtoToEntity(property);
            return await this.propertyRepository.Insert(entity);
        }
        public async Task<bool> UpdateProperty(PropertyDto property)
        {
            var entity = MapDtoToEntity(property);
            return await this.propertyRepository.Update(entity) != 0;
        }
        public async Task<bool> DeleteProperty(long id) => await this.propertyRepository.Delete(id);

        private static PropertyDto MapEntityToDto(Property property)
        {
            return new PropertyDto
            {
                ID = property.ID,
                CreatedDateTime = property.CreatedDateTime,
                IsActive = property.IsActive,
                IsDeleted = property.IsDeleted,
                PropName = property.PropName,
                CategoryID = property.CategoryID,
                ValueType = property.ValueType
            };
        }
        private static Property MapDtoToEntity(PropertyDto property)
        {
            return new Property
            {
                ID = property.ID,
                PropName = property.PropName,
                CategoryID = property.CategoryID,
                ValueType = property.ValueType
            };
        }
    }
}
