using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlarmSystem.Models
{
    public class AlarmObjectViewModel
    {
        public List<Core.Models.AlarmObject> ItemList { get; set; }
        public List<Core.Models.User> UserList { get; set; }
    }
}
