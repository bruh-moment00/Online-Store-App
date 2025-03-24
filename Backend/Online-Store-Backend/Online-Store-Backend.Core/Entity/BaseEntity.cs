using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Online_Store_Backend.Core.Entity
{
    [Serializable]
    [DataContract(IsReference = true)]
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        public Guid ID { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;

        [DataMember]
        public bool IsActive { get; set; } = true;

        [DataMember]
        public bool IsDeleted { get; set; } = false;
    }
}
