using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Backend.Domain.Base.Dto
{
    public class ConnectDto : BaseDto
    {
        public DateTime UpdateDateTime { get; set; } = DateTime.Now;
    }
}
