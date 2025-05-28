using Online_Store_Backend.Domain.Base.Dto;

namespace Online_Store_Backend.Domain.Employees.Dto
{
    public class EmployeeTokenDto : ConnectDto
    {
        public long EmployeeID { get; set; }
        public DateTime ExpirationDate { get; set; } = DateTime.UtcNow.AddDays(30);
        public String? Token { get; set; }
    }
}
