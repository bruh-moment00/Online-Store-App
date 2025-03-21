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
    class OrderedProduct
    {
        [DataMember]
        public Guid OrderID { get; set; }

        [ForeignKey("OrderID")]
        public virtual Order? Order { get; set; }

        [DataMember]
        public Guid ProductID { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product? Product { get; set; }
    }
}
