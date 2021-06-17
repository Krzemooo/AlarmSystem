using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AlarmSystem.Core.Models
{
    public class AlarmSystem
    {
        [Key]
        public int ID { get; set; }
        public string SystemName { get; set; }
        public AlarmObject AlarmObject { get; set; }
    }
}
