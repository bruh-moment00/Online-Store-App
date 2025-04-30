using Online_Store_Backend.Core.Entity;
using Online_Store_Backend.Database.Employees;
using Online_Store_Backend.Database.Orders.Models;
using Online_Store_Backend.Database.Products.Models;
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
    [Table("employee_permission", Schema = "public")]
    public class EmployeePermission : ConnectEntity
    {
        [DataMember]
        [Required]
        public Guid EmployeeID { get; set; }

        [ForeignKey("EmployeeID")]
        public virtual required Employee Employee { get; set; }

        [DataMember]
        [Required]
        public Int32 PermissionID { get; set; }

        [ForeignKey("PermissionID")]
        public virtual required Permission Permission { get; set; }
    }
}
