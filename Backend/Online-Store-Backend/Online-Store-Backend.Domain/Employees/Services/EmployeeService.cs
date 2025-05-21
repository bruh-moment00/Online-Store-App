using Online_Store_Backend.Core.Data.Repository;
using Online_Store_Backend.Database.Employees.Models;
using Online_Store_Backend.Database.Users.Models;
using Online_Store_Backend.Domain.Employees.Dto;
using Online_Store_Backend.Domain.Employees.Services.Interfaces;
using Online_Store_Backend.Domain.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Backend.Domain.Employees.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryAsync<Employee> employeeRepository;
        public EmployeeService(IRepositoryAsync<Employee> employeeRepository) => this.employeeRepository = employeeRepository;

        public async Task<EmployeeDto> GetById(long id)
        {
            var user = await employeeRepository.FindById(id);
            return user == null ? null : EntityToDtoMapping(user);
        }
        public async Task<List<EmployeeDto>> GetAll()
        {
            var users = await employeeRepository.Filter(x => x.IsActive && !x.IsDeleted);
            return users.Select(EntityToDtoMapping).ToList();
        }
        public async Task<long> InsertEmployee(EmployeeDto user)
        {
            var entity = DtoToEntityMapping(user);
            return await employeeRepository.Insert(entity);
        }
        public async Task<bool> UpdateEmployee(EmployeeDto user)
        {
            var entity = DtoToEntityMapping(user);
            return await employeeRepository.Update(entity) != 0;
        }
        public async Task<bool> DeleteEmployee(long id) => await employeeRepository.Delete(id);

        private static EmployeeDto EntityToDtoMapping(Employee user)
        {
            return new EmployeeDto
            {
                ID = user.ID,
                CreatedDateTime = user.CreatedDateTime,
                IsActive = user.IsActive,
                IsDeleted = user.IsDeleted,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                BirthDate = user.BirthDate,
                PhoneNum = user.PhoneNum,
                Gender = user.Gender,
                Login = user.Login,
                PasswordHash = user.PasswordHash
            };
        }
        private static Employee DtoToEntityMapping(EmployeeDto user)
        {
            return new Employee
            {
                ID = user.ID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNum = user.PhoneNum,
                Gender = user.Gender,
                BirthDate = user.BirthDate,
                Login = user.Login,
            };
        }
    }
}
