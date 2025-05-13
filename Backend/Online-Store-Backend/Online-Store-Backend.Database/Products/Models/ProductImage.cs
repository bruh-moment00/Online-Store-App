using Online_Store_Backend.Core.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Online_Store_Backend.Database.Products.Models
{
    [Serializable]
    [DataContract]
    [Table("product_image", Schema = "public")]
    public class ProductImage : BaseEntity
    {        
        [DataMember]
        public String? ImageAddress { get; set; }

        [DataMember]
        public long ProductID { get; set; }

        [ForeignKey("ProductID")]
        public Product? Product { get; set; }
    }
}
