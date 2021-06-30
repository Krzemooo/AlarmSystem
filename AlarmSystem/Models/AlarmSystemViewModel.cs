using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlarmSystem.Models
{
    public class AlarmSystemViewModel
    {
        public List<Core.Models.AlarmSystem> ItemList { get; set; }
        public List<Core.Models.AlarmObject> ObjectList { get; set; }
    }
}
