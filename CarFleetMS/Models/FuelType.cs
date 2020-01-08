using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarFleetMS.Models
{
    public partial class FuelType
    {
        public FuelType()
        {
            Vehicle = new HashSet<Vehicle>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FuelTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<Vehicle> Vehicle { get; set; }

    }
}
