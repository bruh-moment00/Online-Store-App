using Online_Store_Backend.Core.Entity;
using Online_Store_Backend.Database.Employees.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Online_Store_Backend.Database.Permissions.Models
{
    [Serializable]
    [DataContract]
    [Table("employee_permission", Schema = "public")]
    public class EmployeePermission : ConnectEntity
    {
        [DataMember]
        [Required]
        public required long EmployeeID { get; set; }

        [ForeignKey("EmployeeID")]
        public virtual Employee Employee { get; set; }

        [DataMember]
        [Required]
        public required long PermissionID { get; set; }

        [ForeignKey("PermissionID")]
        public virtual Permission Permission { get; set; }
    }
}
