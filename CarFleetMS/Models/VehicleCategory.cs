using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarFleetMS.Models
{
    public partial class VehicleCategory
    {
        public VehicleCategory()
        {
            Vehicle = new HashSet<Vehicle>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleCategoryId { get; set; }
        public string Name { get; set; }

        public ICollection<Vehicle> Vehicle { get; set; }
    }
}
