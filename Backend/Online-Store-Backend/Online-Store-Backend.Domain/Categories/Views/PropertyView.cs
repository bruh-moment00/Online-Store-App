using Online_Store_Backend.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Backend.Domain.Categories.Views
{
    public class PropertyView
    {
        public long PropertyId { get; set; }
        public string? Name { get; set; }
        public long ValueId { get; set; }
        public PropValueType ValueType { get; set; }
        public string? Value { get; set; }
    }
}
