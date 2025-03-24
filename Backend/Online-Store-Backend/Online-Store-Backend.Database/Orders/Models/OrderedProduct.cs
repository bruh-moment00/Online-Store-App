using Online_Store_Backend.Core.Entity;
using Online_Store_Backend.Database.Products.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Backend.Database.Orders.Models
{
    [Serializable]
    [DataContract]
    [Table("order_product", Schema = "public")]
    class OrderedProduct : ConnectEntity
    {
        [DataMember]
        [Required]
        public Guid OrderID { get; set; }

        [ForeignKey("OrderID")]
        public required virtual Order Order { get; set; }

        [DataMember]
        [Required]
        public Guid ProductID { get; set; }

        [ForeignKey("ProductID")]
        public required virtual Product Product { get; set; }
    }
}
