using Online_Store_Backend.Database.Categories.Models;
using Online_Store_Backend.Database.Orders.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Backend.Database.Products.Models
{
    [Serializable]
    [DataContract]
    [Table("product", Schema = "public")]
    class Product
    {       
        [Key]
        [DataMember]
        public Guid ID { get; set; }

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
        public SqlMoney Price { get; set; }

        [DataMember]
        public virtual ICollection<ProductPropValue>? PropsValues { get; set; }

        [DataMember]
        public virtual ICollection<ProductImage>? Images { get; set; }
        public Product(String name)
        {
            Name = name;
        }
    }
}
