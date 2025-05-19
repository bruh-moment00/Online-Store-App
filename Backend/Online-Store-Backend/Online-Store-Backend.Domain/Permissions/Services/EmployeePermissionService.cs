using Online_Store_Backend.Core.Data.Repository;
using Online_Store_Backend.Database.Permissions.Models;
using Online_Store_Backend.Domain.Permissions.Dto;
using Online_Store_Backend.Domain.Permissions.Services.Interfaces;

namespace Online_Store_Backend.Domain.Permissions.Services
{
    public class EmployeePermissionService : IEmployeePermissionService
    {
        private readonly IRepositoryAsync<EmployeePermission> employeePermissionRepository;
        public EmployeePermissionService(IRepositoryAsync<EmployeePermission> employeePermissionRepository) => this.employeePermissionRepository = employeePermissionRepository;
        public async Task<List<EmployeePermissionDto>> GetByEmployeeId(long employeeId)
        {
            var entities = await this.employeePermissionRepository.Filter(x => x.EmployeeID == employeeId);
            return entities.Select(MapEntityToDto).ToList();    
        }
        public async Task<long> InsertEmployeePermission(EmployeePermissionDto employeePermission)
        {
            var entity = MapDtoToEntity(employeePermission);
            return await this.employeePermissionRepository.Insert(entity);
        }
        public async Task<bool> UpdateEmployeePermission(EmployeePermissionDto employeePermission)
        {
            var entity = MapDtoToEntity(employeePermission);
            return await this.employeePermissionRepository.Update(entity) != 0;
        }
        public async Task<bool> DeleteEmployeePermission(long id) => await this.employeePermissionRepository.Delete(id);

        private static EmployeePermissionDto MapEntityToDto(EmployeePermission employeePermission)
        {
            return new EmployeePermissionDto
            {
                ID = employeePermission.ID,
                CreatedDateTime = employeePermission.CreatedDateTime,
                IsActive = employeePermission.IsActive,
                IsDeleted = employeePermission.IsDeleted,
                UpdateDateTime = employeePermission.UpdateDateTime,
                EmployeeID = employeePermission.EmployeeID,
                PermissionID = employeePermission.PermissionID,
            };
        }
        private static EmployeePermission MapDtoToEntity(EmployeePermissionDto employeePermission)
        {
            return new EmployeePermission
            {
                ID = employeePermission.ID,
                EmployeeID = employeePermission.EmployeeID,
                PermissionID = employeePermission.PermissionID
            };
        }
    }
}
