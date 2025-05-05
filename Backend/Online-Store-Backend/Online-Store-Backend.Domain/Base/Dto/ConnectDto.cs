using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Backend.Domain.Base.Dto
{
    public class ConnectDto
    {
        public long Id { get; set; }
        public DateTime DateOfAdding { get; set; } = DateTime.Now;
    }
}
