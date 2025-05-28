using Online_Store_Backend.Core.Entity;
using Online_Store_Backend.Database.Employees.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Online_Store_Backend.Database.Users.Models
{
    [Serializable]
    [DataContract]
    [Table("employee_token", Schema = "public")]
    public class EmployeeToken : ConnectEntity
    {
        [DataMember]
        public long EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]
        public virtual Employee? Employee { get; set; }
        public DateTime ExpirationDate { get; set; } = DateTime.UtcNow.AddDays(30);
        [DataMember]
        public String? Token { get; set; }
    }
}

