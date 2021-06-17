using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AlarmSystem.Core.Models
{
    public class Action
    {
        [Key]
        public int ID { get; set; }
        public string ActionName { get; set; }
        public string ActionTask { get; set; }
    }
}
