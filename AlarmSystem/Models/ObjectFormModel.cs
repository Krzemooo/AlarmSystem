using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlarmSystem.Models
{
    public class ObjectFormModel
    {
        public int? ID { get; set; }
        [Display(Name = "Nazwa objektu")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Właściciel obiektu")]
        [Required]
        public int OwnerID { get; set; }

        public List<Core.Models.User> UserList { get; set; }
    }
}
