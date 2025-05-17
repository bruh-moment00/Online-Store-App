using Online_Store_Backend.Domain.Base.Dto;

namespace Online_Store_Backend.Domain.Permissions.Dto
{
    public class PermissionDto : BaseDto
    {
        public String? Name { get; set; }
        public String? Description { get; set; }
    }
}
