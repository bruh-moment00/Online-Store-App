using Online_Store_Backend.Domain.Base.Dto;
using Online_Store_Backend.Enums;

namespace Online_Store_Backend.Domain.Orders.Dto
{
    public class OrderDto : BaseDto
    {
        public Double TotalPrice { get; set; }
        public Guid UserID { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
    }
}
