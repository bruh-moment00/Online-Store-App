using Online_Store_Backend.Core.Data.Repository;
using Online_Store_Backend.Database.Permissions.Models;
using Online_Store_Backend.Domain.Categories.Dto;
using Online_Store_Backend.Domain.Permissions.Dto;
using Online_Store_Backend.Domain.Permissions.Services.Interfaces;

namespace Online_Store_Backend.Domain.Permissions.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IRepositoryAsync<Permission> permissionRepository;
        public PermissionService(IRepositoryAsync<Permission> permissionRepository) => this.permissionRepository = permissionRepository;
        public async Task<PermissionDto> GetById(long id)
        {
            var entity = await this.permissionRepository.FindById(id);
            return entity == null ? null : MapEntityToDto(entity); 
        }
        public async Task<List<PermissionDto>> GetAll()
        {
            var entities = await this.permissionRepository.Filter(x => !x.IsDeleted);
            return entities.Select(MapEntityToDto).ToList();
        }
        public async Task<long> InsertPermission(PermissionDto permission)
        {
            var entity = MapDtoToEntity(permission);
            return await this.permissionRepository.Insert(entity);
        }
        public async Task<bool> UpdatePermission(PermissionDto permission)
        {
            var entity = MapDtoToEntity(permission);
            return await this.permissionRepository.Update(entity) != 0;
        }
        public async Task<bool> DeletePermission(long id) => await this.permissionRepository.Delete(id);

        private static PermissionDto MapEntityToDto(Permission permission) 
        {
            return new PermissionDto
            {
                ID = permission.ID,
                CreatedDateTime = permission.CreatedDateTime,
                IsActive = permission.IsActive,
                IsDeleted = permission.IsDeleted,
                Name = permission.Name,
                Description = permission.Description,
            };
        }
        private static Permission MapDtoToEntity(PermissionDto permission)
        {
            return new Permission
            {
                ID = permission.ID,
                Name = permission.Name,
                Description = permission.Description,
            };
        }
    }
}
