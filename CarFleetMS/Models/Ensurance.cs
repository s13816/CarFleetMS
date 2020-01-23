using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarFleetMS.Models
{
    public partial class Ensurance
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnsuranceId { get; set; }
        public string EnsuranceNumber { get; set; }
        public string NameOfTheCompany { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal OCAmount { get; set; }
        public decimal ACAmount { get; set; }
        public int VehicleId { get; set; }
        public int PersonCompanyId { get; set; }

        public PersonCompany PersonCompany { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
