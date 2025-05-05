using Online_Store_Backend.Database.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Online_Store_Backend.Database.Employees.Models
{
    [Serializable]
    [DataContract]
    [Table("employee", Schema = "public")]
    public class Employee : BaseEntity
    {
        [DataMember]
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [DataMember]
        [MaxLength(50)]
        [Required]
        public string? LastName { get; set; }

        [DataMember]
        [MaxLength(20)]
        [Required]
        public string? PhoneNum { get; set; }

        [DataMember]
        [MaxLength(100)]
        [Required]
        public string? Email { get; set; }

        [DataMember]
        public bool? Gender { get; set; }

        [DataMember]
        public DateTime? BirthDate { get; set; }

        [DataMember]
        [MaxLength(255)]
        public string Login { get; set; }

        [DataMember]
        [MaxLength(255)]
        public string? PasswordHash { get; set; }
    }
}
