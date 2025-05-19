using Online_Store_Backend.Domain.Permissions.Dto;

namespace Online_Store_Backend.Domain.Permissions.Services.Interfaces
{
    public interface IPermissionService
    {
        Task<PermissionDto> GetById(long id);
        Task<List<PermissionDto>> GetAll();
        Task<long> InsertPermission(PermissionDto permission);
        Task<bool> UpdatePermission(PermissionDto permission);
        Task<bool> DeletePermission(long id);
    }
}
