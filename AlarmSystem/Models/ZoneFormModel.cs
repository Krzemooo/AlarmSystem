using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlarmSystem.Models
{
    public class ZoneFormModel
    {
        public int? ID { get; set; }
        [Display(Name = "Nazwa strefy")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "System")]
        [Required]
        public int SystemID { get; set; }

        public List<Core.Models.AlarmSystem> AlarmSystems { get; set; }
    }
}
