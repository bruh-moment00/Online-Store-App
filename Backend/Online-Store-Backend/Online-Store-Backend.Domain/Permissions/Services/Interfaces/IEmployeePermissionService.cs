using Online_Store_Backend.Domain.Permissions.Dto;

namespace Online_Store_Backend.Domain.Permissions.Services.Interfaces
{
    public interface IEmployeePermissionService
    {
        Task<List<EmployeePermissionDto>> GetByEmployeeId(long employeeId);
        Task<long> InsertEmployeePermission(EmployeePermissionDto employeePermissionDto);
        Task<bool> UpdateEmployeePermission(EmployeePermissionDto employeePermissionDto);
        Task<bool> DeleteEmployeePermission(long id);
    }
}
