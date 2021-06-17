using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AlarmSystem.Core.Models
{
    public class InputOutput
    {
        [Key]
        public int ID { get; set; }
        public string IOName { get; set; }
        public string IOPlace { get; set; }
        public AlarmSystem AlarmSystem { get; set; }
    }
}
