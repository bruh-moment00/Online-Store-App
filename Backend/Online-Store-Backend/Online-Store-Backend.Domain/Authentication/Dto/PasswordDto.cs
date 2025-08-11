using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Backend.Domain.Authentication.Dto
{
    public class PasswordDto
    {
        public long ID { get; set; }
        public required string OldPassword { get; set; }
        public required string NewPassword { get; set; }
        public required string NewPasswordConfirm { get; set; }
    }
}
