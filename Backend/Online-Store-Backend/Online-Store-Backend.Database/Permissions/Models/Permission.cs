using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Online_Store_Backend.Database.Permissions.Models
{
    [Serializable]
    [DataContract]
    [Table("permission", Schema = "public")]
    public class Permission
    {
        [Key]
        [DataMember]
        public Int32 ID { get; set; }

        [DataMember]
        public String? Name { get; set; }

        [DataMember]
        public String? Description { get; set; }
    }
}
