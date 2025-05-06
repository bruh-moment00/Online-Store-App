using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
