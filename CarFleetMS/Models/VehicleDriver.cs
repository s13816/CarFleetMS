using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarFleetMS.Models
{
    public partial class VehicleDriver
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleDriverId { get; set; }
        public int VehicleId { get; set; }
        public int DriverId { get; set; }


        public Driver Driver { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
