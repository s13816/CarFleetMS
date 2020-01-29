using CarFleetMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarFleetMS.Data.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Vehicle> Vehicles { get; set; }
        public IEnumerable<CarFleetMS.Models.Brand> Brands { get; set; }
        public IEnumerable<CarFleetMS.Models.Model> Models { get; set; }
        public IEnumerable<CarFleetMS.Models.Ensurance> Ensurances { get; set; }
        public IEnumerable<CarFleetMS.Models.TechnicalExamination> TechnicalExaminations { get; set; }
        public IEnumerable<Repair> Repairs { get; set; }
    }
}
