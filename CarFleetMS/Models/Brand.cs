using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarFleetMS.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Models = new HashSet<Model>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandId { get; set; }
        public string Name { get; set; }

        public ICollection<Model> Models { get; set; }
    }
}
