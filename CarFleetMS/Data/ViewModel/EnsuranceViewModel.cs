using CarFleetMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarFleetMS.Data.ViewModel
{
    public class EnsuranceViewModel
    {
        public IEnumerable<Ensurance> Ensurances { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; }
        public IEnumerable<PersonCompany> People { get; set; }
    }
}
