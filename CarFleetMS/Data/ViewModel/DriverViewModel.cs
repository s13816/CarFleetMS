using CarFleetMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarFleetMS.Data.ViewModel
{
    public class DriverViewModel
    {
        public IEnumerable<VehicleDriver> VehicleDrivers { get; set; }
        public IEnumerable<Driver> Drivers { get; set; }
        public IEnumerable<PersonCompany> People { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Model> Models { get; set; }
    }
}
