using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AlarmSystem.Core.Models
{
    public class AlarmScenerio
    {
        [Key]
        public int ID { get; set; }
        public string ScenerioName { get; set; }
        public AlarmSystem AlarmSystem { get; set; }
    }
}
