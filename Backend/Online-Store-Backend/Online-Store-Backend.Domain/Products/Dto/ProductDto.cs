using Online_Store_Backend.Domain.Base.Dto;

namespace Online_Store_Backend.Domain.Products.Dto
{
    public class ProductDto : BaseDto
    {
        public String Name { get; set; }
        public String? Description { get; set; }
        public long? CategoryID { get; set; }
        public Double Price { get; set; }
    }
}
