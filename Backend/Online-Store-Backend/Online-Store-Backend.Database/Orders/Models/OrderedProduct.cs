using Online_Store_Backend.Core.Entity;
using Online_Store_Backend.Database.Products.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Online_Store_Backend.Database.Orders.Models
{
    [Serializable]
    [DataContract]
    [Table("order_product", Schema = "public")]
    public class OrderedProduct : ConnectEntity
    {
        [DataMember]
        [Required]
        public Int64 OrderID { get; set; }

        [ForeignKey("OrderID")]
        public required virtual Order Order { get; set; }

        [DataMember]
        [Required]
        public Int64 ProductID { get; set; }

        [ForeignKey("ProductID")]
        public required virtual Product Product { get; set; }
    }
}
