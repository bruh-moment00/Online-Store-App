using Online_Store_Backend.Domain.Base.Dto;

namespace Online_Store_Backend.Domain.Users.Dto
{
    public class UserTokenDto : ConnectDto
    {
        public long UserID { get; set; }
        public DateTime ExpirationDate { get; set; } = DateTime.UtcNow.AddDays(30);
        public String? Token { get; set; }
    }
}
