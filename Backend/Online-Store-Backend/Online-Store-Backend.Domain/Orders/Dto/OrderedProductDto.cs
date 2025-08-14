using Online_Store_Backend.Domain.Base.Dto;

namespace Online_Store_Backend.Domain.Orders.Dto
{
    public class OrderedProductDto : ConnectDto
    {
        public long OrderID { get; set; }
        public long ProductID { get; set; }
        public double PriceWhenAdded { get; set; }
    }
}
