using Online_Store_Backend.Database.Products.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Online_Store_Backend.Database.Categories.Models
{
    [Serializable]
    [DataContract]
    [Table("category", Schema = "public")]
    public class Category
    {
        [Key]
        [DataMember]
        public Int32 ID { get; set; }

        [DataMember]
        public String? Name { get; set; }

        public virtual ICollection<Property>? Props { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
}
