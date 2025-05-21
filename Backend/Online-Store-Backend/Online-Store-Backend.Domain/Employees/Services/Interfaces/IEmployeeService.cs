using Online_Store_Backend.Domain.Employees.Dto;

namespace Online_Store_Backend.Domain.Employees.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> GetById(long id);
        Task<List<EmployeeDto>> GetAll();
        Task<long> InsertEmployee (EmployeeDto user);
        Task<bool> UpdateEmployee(EmployeeDto user);
        Task<bool> DeleteEmployee(long id);
    }
}
