using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarFleetMS.Models
{
    public partial class Repair
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RepairId { get; set; }
        public int VehicleId { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
