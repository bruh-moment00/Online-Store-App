using Online_Store_Backend.Enums;

namespace Online_Store_Backend.Domain.Categories.Dto
{
    public class PropertyDto
    {
        public Guid ID { get; set; }
        public Int32 CategoryID { get; set; }
        public String? PropName { get; set; }
        public PropValueType ValueType { get; set; }
    }
}
