using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Backend.Core.Entity
{
    [Serializable]
    [DataContract(IsReference = true)]
    public abstract class ConnectEntity
    {
        [DataMember]
        public DateTime DateOfAdding { get; set; } = DateTime.Now;
    }
}
