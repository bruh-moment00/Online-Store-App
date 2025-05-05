using Online_Store_Backend.Domain.Base.Dto;

namespace Online_Store_Backend.Domain.Categories.Dto
{
    public class ProductPropValueDto : ConnectDto
    {
        public Guid ProductID { get; set; }
        public Guid PropID { get; set; }
        public String? Value { get; set; }
    }
}
