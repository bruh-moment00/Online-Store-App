using Online_Store_Backend.Domain.Base.Dto;

namespace Online_Store_Backend.Domain.Users.Dto
{
    public class UserDto : BaseDto
    {
        public String FirstName { get; set; }
        public String? LastName { get; set; }
        public String PhoneNum { get; set; }
        public String Email { get; set; }
        public bool? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public String? Login { get; set; }
        public String? PasswordHash { get; set; }
    }
}
