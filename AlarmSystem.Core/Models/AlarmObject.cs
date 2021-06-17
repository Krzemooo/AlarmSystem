using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AlarmSystem.Core.Models
{
    public class AlarmObject
    {
        [Key]
        public int ID { get; set; }
        public string ObjectName { get; set; }
        public User ObjectOwner { get; set; }
    }
}
