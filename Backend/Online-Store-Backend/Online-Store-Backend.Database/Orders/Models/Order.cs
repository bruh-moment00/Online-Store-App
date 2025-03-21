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
    class Order
    {
        [Key]
        [DataMember]
        public Guid OrderID { get; set; }

        [DataMember]
        public DateTime CreatedOn { get; set; }

        [DataMember]
        public SqlMoney TotalPrice { get; set; }
        
        public ICollection<Product> OrderedProducts { get; set; }

        [DataMember]
        public Guid UserID { get; set; }

        [Required]
        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        [Required]
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        
        public Order(User user, ICollection<Product> products)
        {
            User = user;
            OrderedProducts = products;
        }
    }
}
