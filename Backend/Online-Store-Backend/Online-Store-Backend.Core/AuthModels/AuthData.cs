using System.ComponentModel.DataAnnotations;

namespace Online_Store_Backend.Core.AuthModels
{
    public class AuthData
    {
        public string? Login { get; set; }
        public string? PhoneNum { get; set; }
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public required string Password { get; set; }
    }
}
