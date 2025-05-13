using Online_Store_Backend.Domain.Base.Dto;

namespace Online_Store_Backend.Domain.Products.Dto
{
    public class ProductImageDto : BaseDto
    {
        public String? ImageAddress { get; set; }
        public long ProductID { get; set; }
    }
}
