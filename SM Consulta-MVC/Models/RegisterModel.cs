using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Auth_Api.Models
{
    public class RegisterModel
    {
        [Display(Name = "Name")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "You need to provide long enough Name")]
        [Required(ErrorMessage = "You need to add a valid Name")]
        public string Name { get; set; }


        [Display(Name = "Salary")]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        [Required(ErrorMessage = "You need to add a salary")]
        public int Salary { get; set; }

    }
}
