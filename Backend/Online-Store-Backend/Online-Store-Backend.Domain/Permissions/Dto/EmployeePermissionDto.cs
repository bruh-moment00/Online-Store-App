using Online_Store_Backend.Domain.Base.Dto;

namespace Online_Store_Backend.Domain.Permissions.Dto
{
    public class EmployeePermissionDto : ConnectDto
    {
        public long EmployeeID { get; set; }
        public long PermissionID { get; set; }
    }
}
