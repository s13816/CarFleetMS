using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarFleetMS.Models
{
    public class Institution
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InstitutionId { get; set; }
        public string Name { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }

        public Address Address { get; set; }
        //public ICollection<Vehicle> Vehicle { get; set; }
    }
}
