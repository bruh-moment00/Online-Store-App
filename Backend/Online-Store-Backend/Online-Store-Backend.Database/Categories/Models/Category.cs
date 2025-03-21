using Online_Store_Backend.Database.Products.Models;
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
    [Table("category", Schema = "public")]
    class Category
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
