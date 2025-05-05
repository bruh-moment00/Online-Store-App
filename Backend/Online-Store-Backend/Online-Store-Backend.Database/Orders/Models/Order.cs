using Online_Store_Backend.Database.Entity;
using Online_Store_Backend.Database.Users.Models;
using Online_Store_Backend.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

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
