using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarFleetMS.Models;
using Microsoft.EntityFrameworkCore;
using CarFleetMS.Data.ViewModel;

namespace CarFleetMS.Controllers
{
    public class HomeController : Controller
    {
        CarFleetMSContext _context = new CarFleetMSContext();
        public IActionResult Index()
        {
            _context.Vehicle.ToList();
            _context.Brand.ToList();


            var carFleetMSContext = _context.Vehicle.Include(v => v.FuelType).Include(v => v.Holder).Include(v => v.Model).Include(v => v.Owner).Include(v => v.VehicleCategory).Include(v => v.VehicleKind).Include(v => v.VehicleType);

            List<Ensurance> ensuranceList = _context.Ensurance.ToList();
            List<TechnicalExamination> techList = _context.TechnicalExamination.ToList();
            List<Vehicle> vehicleList = _context.Vehicle.ToList();

            List<Ensurance> ensFinal = _context.Ensurance.ToList();
            List<TechnicalExamination> techFinal = _context.TechnicalExamination.ToList();
            List<Vehicle> vehicleFinal = _context.Vehicle.ToList();


            foreach (Ensurance ens1 in ensuranceList)
            {
                foreach (Ensurance ens2 in ensuranceList)
                {
                    if (ens1.VehicleId.Equals(ens2.VehicleId) && DateTime.Compare(ens1.EndDate, ens2.EndDate) > 0)
                    {
                        ensFinal.Remove(ens2);
                    }
                }
            }

            foreach (TechnicalExamination tech1 in techList)
            {
                foreach (TechnicalExamination tech2 in techList)
                {
                    if (tech1.VehicleId.Equals(tech2.VehicleId) && DateTime.Compare(tech1.Validity, tech2.Validity) > 0)
                    {
                        techFinal.Remove(tech2);
                    }
                }
            }

            foreach(Vehicle v in vehicleList)
            {

            }

            HomeViewModel homeViewModel = new HomeViewModel
            {
                Vehicles = _context.Vehicle,
                Brands = _context.Brand,
                Models = _context.Model,
                Ensurances = ensFinal,
                TechnicalExaminations = techFinal,
                Repairs = _context.Repair
            };



            //return View(await carFleetMSContext.ToListAsync());
            return View(homeViewModel);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
