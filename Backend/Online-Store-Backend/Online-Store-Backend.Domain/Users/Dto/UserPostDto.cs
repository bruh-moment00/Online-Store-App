using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Backend.Domain.Users.Dto
{
    public class UserPostDto : UserDto
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
