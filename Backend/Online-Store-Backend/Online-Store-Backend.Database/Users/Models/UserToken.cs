using Online_Store_Backend.Core.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Online_Store_Backend.Database.Users.Models
{
    [Serializable]
    [DataContract]
    public class UserToken : ConnectEntity
    {
        [DataMember]
        public long UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User? User { get; set; }
        public DateTime ExpirationDate { get; set; } = DateTime.UtcNow.AddDays(30);
        [DataMember]
        public String? Token { get; set; }
    }
}
