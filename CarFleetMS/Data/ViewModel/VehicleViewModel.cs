using CarFleetMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CarFleetMS.Data.ViewModel
{
    public class VehicleViewModel
    {
        //public Vehicle Vehicle { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; }
        public IEnumerable<CarFleetMS.Models.Brand> Brands { get; set; }
        public IEnumerable<CarFleetMS.Models.Model> Models { get; set; }
        public IEnumerable<CarFleetMS.Models.Ensurance> Ensurances { get; set; }
        public IEnumerable<CarFleetMS.Models.TechnicalExamination> TechnicalExaminations { get; set; }
        //public List<SelectListItem> Brands { get; set; }
        //public List<SelectListItem> Models { get; set; }
        //public List<SelectListItem> TechnicalExaminations { get; set; }
        //public IEnumerable<VehicleViewModel> VehicleModels { get; set; }
        //public void VehicleModel(Vehicle vehicle, Brand brand, Model model, TechnicalExamination service)
        //{
        //    VehicleModels.add()
        //}
    }
}
