using Online_Store_Backend.Domain.Base.Dto;
using Online_Store_Backend.Enums;

namespace Online_Store_Backend.Domain.Categories.Dto
{
    public class PropertyDto : BaseDto
    {
        public long CategoryID { get; set; }
        public String? PropName { get; set; }
        public PropValueType ValueType { get; set; }
    }
}
