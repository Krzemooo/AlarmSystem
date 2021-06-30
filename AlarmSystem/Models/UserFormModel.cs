using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlarmSystem.Models
{
    public class UserFormModel
    {
        public int? Id { get; set; }

        [Display(Name = "Adres email")]
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [Display(Name = "Rola")]
        [Required]
        public string Role { get; set; }
    }
}
