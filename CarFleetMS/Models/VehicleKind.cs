using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarFleetMS.Models
{
    public partial class VehicleKind
    {
        public VehicleKind()
        {
            Vehicle = new HashSet<Vehicle>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleKindId { get; set; }
        public string Name { get; set; }

        public ICollection<Vehicle> Vehicle { get; set; }
    }
}
