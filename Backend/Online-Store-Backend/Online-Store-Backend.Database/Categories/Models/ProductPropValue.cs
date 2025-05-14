using Online_Store_Backend.Core.Entity;
using Online_Store_Backend.Database.Products.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Online_Store_Backend.Database.Categories.Models
{
    [Serializable]
    [DataContract]
    [Table("product_property_value", Schema = "public")]
    public class ProductPropValue : ConnectEntity
    {
        [DataMember]
        [Required]
        public required long ProductID { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }

        [DataMember]
        [Required]
        public required long PropID { get; set; }

        [ForeignKey("PropID")]
        public virtual Property Property { get; set; }

        [DataMember]
        [MaxLength(100)]
        public String? Value { get; set; }

    }
}
