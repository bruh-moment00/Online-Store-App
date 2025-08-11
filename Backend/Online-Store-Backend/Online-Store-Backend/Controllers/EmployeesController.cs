using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_Store_Backend.Domain.Authentication.Dto;
using Online_Store_Backend.Domain.Employees.Dto;
using Online_Store_Backend.Domain.Employees.Services.Interfaces;

namespace Online_Store_Backend.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        [Authorize(Roles = "employee")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await employeeService.GetAll();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "employee")]
        public async Task<IActionResult> GetEmployeeById(long id)
        {
            var employee = await employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        [Authorize(Roles = "employee")]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeePostDto employee)
        {
            if (employee == null)
            {
                return BadRequest("Invalid employee data.");
            }
            if (string.IsNullOrWhiteSpace(employee.Password))
            {
                return BadRequest("Password is required.");
            }
            if (employee.Password != employee.ConfirmPassword)
            {
                return BadRequest("Passwords do not match.");
            }
            var createdEmployeeID = await employeeService.InsertEmployee(employee);
            return Ok(createdEmployeeID);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "employee")]
        public async Task<IActionResult> UpdateEmployee(long id, [FromBody] EmployeeDto employee)
        {
            if (employee == null || id != employee.ID)
            {
                return BadRequest("Invalid employee data.");
            }
            var updated = await employeeService.UpdateEmployee(employee);
            if (!updated)
            {
                return NotFound();
            }
            return Ok(true);
        }

        [HttpPut("{id}/password")]
        [Authorize(Roles = "employee")]
        public async Task<IActionResult> ChangePassword(long id, [FromBody] PasswordDto passwordDto)
        {
            if (passwordDto == null || id != passwordDto.ID)
            {
                return BadRequest("Invalid password data.");
            }
            if (passwordDto.NewPassword != passwordDto.NewPasswordConfirm)
            {
                return BadRequest("New passwords do not match.");
            }
            var changed = await employeeService.ChangePassword(passwordDto);
            if (!changed)
            {
                return NotFound();
            }
            return Ok(true);
        }

        [HttpDelete]
        [Authorize(Roles = "employee")]
        public async Task<IActionResult> DeleteEmployee(long id)
        {
            var result = await employeeService.DeleteEmployee(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
