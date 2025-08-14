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
        public required long OrderID { get; set; }

        [ForeignKey("OrderID")]
        public virtual Order Order { get; set; }

        [DataMember]
        [Required]
        public required long ProductID { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
        [DataMember]
        [Required]
        public required double PriceWhenAdded { get; set; }
    }
}
