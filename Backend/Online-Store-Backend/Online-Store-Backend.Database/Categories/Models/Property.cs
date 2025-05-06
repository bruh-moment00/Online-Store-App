using Online_Store_Backend.Core.Entity;
using Online_Store_Backend.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Online_Store_Backend.Database.Categories.Models
{
    [Serializable]
    [DataContract]
    [Table("category_prop", Schema = "public")]
    public class Property : BaseEntity
    {
        [DataMember]
        public Int64 CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category? Category { get; set; }

        [DataMember]
        [Required]
        [MaxLength(100)]
        public String? PropName { get; set; }

        [DataMember]
        [Required]
        public PropValueType ValueType { get; set; }
    }
}
