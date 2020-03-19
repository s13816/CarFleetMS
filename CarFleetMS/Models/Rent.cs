using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarFleetMS.Models
{
    public partial class Rent
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RentId { get; set; }
        public int VehicleId { get; set; }
        public int DriverId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }


        public Driver Driver { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
