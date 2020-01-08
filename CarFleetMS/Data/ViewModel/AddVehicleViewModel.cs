using CarFleetMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarFleetMS.Data.ViewModel
{
    public class AddVehicleViewModel
    {
        public Vehicle Vehicle { get; set; }
        public List<SelectListItem> People { get; set; }
        public List<SelectListItem> Brands { get; set; }
        public List<SelectListItem> Models { get; set; }
        public List<SelectListItem> VehicleTypes { get; set; }
        public List<SelectListItem> VehicleCategories { get; set; }
        public List<SelectListItem> FuelTypes { get; set; }
        public List<SelectListItem> VehicleKinds { get; set; }


    }
}
