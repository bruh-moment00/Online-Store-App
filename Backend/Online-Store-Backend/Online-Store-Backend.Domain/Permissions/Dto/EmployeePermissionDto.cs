using Online_Store_Backend.Domain.Base.Dto;

namespace Online_Store_Backend.Domain.Permissions.Dto
{
    public class EmployeePermissionDto : ConnectDto
    {
        public Guid EmployeeID { get; set; }
        public Int32 PermissionID { get; set; }
    }
}
