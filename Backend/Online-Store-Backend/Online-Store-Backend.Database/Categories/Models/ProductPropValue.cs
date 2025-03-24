using Online_Store_Backend.Core.Entity;
using Online_Store_Backend.Database.Products.Models;
using Online_Store_Backend.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Backend.Database.Categories.Models
{
    [Serializable]
    [DataContract]
    [Table("product_property_value", Schema = "public")]
    class ProductPropValue : ConnectEntity
    {
        [DataMember]
        [Required]
        public Guid ProductID { get; set; }

        [ForeignKey("ProductID")]
        public virtual required Product Product { get; set; }

        [DataMember]
        [Required]
        public Guid PropID { get; set; }

        [ForeignKey("PropID")]
        public virtual required Property Property { get; set; }

        [DataMember]
        [MaxLength(100)]
        public String? Value { get; set; }

    }
}
