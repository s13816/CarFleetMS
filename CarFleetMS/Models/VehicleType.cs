using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarFleetMS.Models
{
    public partial class VehicleType
    {
        public VehicleType()
        {
            Vehicle = new HashSet<Vehicle>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleTypeId { get; set; }
        public string Variant { get; set; }
        public string Version { get; set; }

        public ICollection<Vehicle> Vehicle { get; set; }
    }
}
