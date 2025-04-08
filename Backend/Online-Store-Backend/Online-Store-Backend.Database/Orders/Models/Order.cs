using Online_Store_Backend.Core.Entity;
using Online_Store_Backend.Database.Products.Models;
using Online_Store_Backend.Database.Users.Models;
using Online_Store_Backend.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Backend.Database.Orders.Models
{
    [Serializable]
    [DataContract]
    [Table("order", Schema = "public")]
    public class Order : BaseEntity
    {
        [DataMember]
        public Double TotalPrice { get; set; }
        
        public ICollection<OrderedProduct>? OrderedProducts { get; set; }

        [DataMember]
        public Guid UserID { get; set; }

        [Required]
        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        [Required]
        [DataMember]
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
    }
}
