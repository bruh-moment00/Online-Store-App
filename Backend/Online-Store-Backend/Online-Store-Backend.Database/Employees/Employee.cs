using Online_Store_Backend.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Backend.Database.Employees
{
    [Serializable]
    [DataContract]
    [Table("employee", Schema = "public")]
    public class Employee : BaseEntity
    {
        [DataMember]
        [MaxLength(50)]
        [Required]
        public String FirstName { get; set; }

        [DataMember]
        [MaxLength(50)]
        [Required]
        public String? LastName { get; set; }

        [DataMember]
        [MaxLength(20)]
        [Required]
        public String? PhoneNum { get; set; }

        [DataMember]
        [MaxLength(100)]
        [Required]
        public String? Email { get; set; }

        [DataMember]
        public bool? Gender { get; set; }

        [DataMember]
        public DateTime? BirthDate { get; set; }

        [DataMember]
        [MaxLength(255)]
        public String Login { get; set; }

        [DataMember]
        [MaxLength(255)]
        public String? PasswordHash { get; set; }

        public Employee(String firstName, String login)
        {
            FirstName = firstName;
            Login = login;
        }
    }
}
