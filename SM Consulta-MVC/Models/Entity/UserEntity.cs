
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace SM_Consulta_MVC.Models.Entity
{
    public class UserEntity
    {
        [Key]
        public int UserId { get; set; }


        [MinLength(3)]
        [MaxLength(25)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int Salary { get; set; }

        public int IncomeTax { get; set; }

        public int HealthSocialInsurance { get; set; }
        [Required]
        public int TotalTaxes { get; set; }
        [Required]
        public int NetSaLary { get; set; }

    }
}
