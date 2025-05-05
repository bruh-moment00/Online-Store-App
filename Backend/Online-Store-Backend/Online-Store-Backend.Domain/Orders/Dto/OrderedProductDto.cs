using Online_Store_Backend.Domain.Base.Dto;

namespace Online_Store_Backend.Domain.Orders.Dto
{
    public class OrderedProductDto : ConnectDto
    {
        public Guid OrderID { get; set; }
        public Guid ProductID { get; set; }
    }
}
