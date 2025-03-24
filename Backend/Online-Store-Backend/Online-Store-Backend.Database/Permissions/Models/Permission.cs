using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Backend.Database.Permissions.Models
{
    [Serializable]
    [DataContract]
    [Table("permission", Schema = "public")]
    class Permission
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
