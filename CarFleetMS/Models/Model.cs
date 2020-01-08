using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarFleetMS.Models
{
    public partial class Model
    {
        public Model()
        {
            Vehicle = new HashSet<Vehicle>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ModelId { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }

        public Brand Brand { get; set; }
        public ICollection<Vehicle> Vehicle { get; set; }
    }
}
