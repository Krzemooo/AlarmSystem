using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlarmSystem.Models
{
    public class SystemFormModel
    {
        public int? ID { get; set; }
        [Display(Name = "Nazwa systemu")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Objekt alarmowy")]
        [Required]
        public int ObjectID { get; set; }

        public List<Core.Models.AlarmObject> AlarmObjects { get; set; }
    }
}
