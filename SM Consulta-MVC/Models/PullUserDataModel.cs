using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SM_Consulta_MVC.Models
{
    public class PullUserDataModel
    {
        public string Name { get; set; }

        public int Salary { get; set; }

        public int IncomeTax { get; set; }

        public int HealthSocialInsurance { get; set; }

        public int TotalTaxes { get; set; }

        public int NetSaLary { get; set; }
    }
}
