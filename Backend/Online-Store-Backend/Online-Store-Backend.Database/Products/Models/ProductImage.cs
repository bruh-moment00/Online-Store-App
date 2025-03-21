using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Backend.Database.Products.Models
{
    [Serializable]
    [DataContract]
    [Table("product_image", Schema = "public")]
    class ProductImage
    {
        [Key]
        [DataMember]
        public Guid ID { get; set; }
        
        [DataMember]
        public String? ImageAddress { get; set; }

        [DataMember]
        public Guid ProductID { get; set; }

        [ForeignKey("ProductID")]
        public Product? Product { get; set; }
    }
}
