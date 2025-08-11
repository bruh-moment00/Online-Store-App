using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Backend.Domain.Employees.Dto
{
    public class EmployeePostDto : EmployeeDto
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
