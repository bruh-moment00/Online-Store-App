using System.Runtime.Serialization;

namespace Online_Store_Backend.Core.Entity
{
    [Serializable]
    [DataContract(IsReference = true)]
    public abstract class ConnectEntity : BaseEntity
    {
        [DataMember]
        public DateTime UpdateDateTime { get; set; } = DateTime.Now;
    }
}
