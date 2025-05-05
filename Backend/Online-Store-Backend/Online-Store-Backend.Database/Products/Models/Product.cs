using Online_Store_Backend.Database.Entity;
using Online_Store_Backend.Database.Categories.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Online_Store_Backend.Database.Products.Models
{
    [Serializable]
    [DataContract]
    [Table("product", Schema = "public")]
    public class Product : BaseEntity
    {       
        [DataMember]
        [MaxLength(255)]
        [Required]
        public String Name { get; set; }

        [DataMember]
        public String? Description { get; set; }

        [DataMember]
        public Int32? CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category? Category { get; set; }

        [DataMember]
        public Double Price { get; set; }

        [DataMember]
        public virtual ICollection<ProductPropValue>? PropsValues { get; set; }

        [DataMember]
        public virtual ICollection<ProductImage>? Images { get; set; }
    }
}
