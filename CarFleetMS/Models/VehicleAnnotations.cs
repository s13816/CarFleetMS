using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarFleetMS.Models
{
    public partial class VehicleAnnotations
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleAnnotationId { get; set; }
        public string Content { get; set; }
        public DateTime? Date { get; set; }
        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
