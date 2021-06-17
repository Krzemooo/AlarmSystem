using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AlarmSystem.Core.Models
{
    public class IOInAlarmZone
    {
        [Key]
        public int ID { get; set; }
        public InputOutput InputOutput { get; set; }
        public AlarmZone AlarmZone { get; set; }
    }
}
