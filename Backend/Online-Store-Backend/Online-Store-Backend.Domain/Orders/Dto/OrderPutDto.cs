using Online_Store_Backend.Domain.Base.Dto;
using Online_Store_Backend.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Backend.Domain.Orders.Dto
{
    public class OrderPutDto
    {
        public long ID { get; set; }
        public long UserID { get; set; }
        public OrderStatus Status { get; set; }
    }
}
