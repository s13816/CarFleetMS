using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarFleetMS.Models
{
    public partial class TechnicalExamination
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceId { get; set; }
        public DateTime DateOfExam { get; set; }
        public DateTime Validity { get; set; }
        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
