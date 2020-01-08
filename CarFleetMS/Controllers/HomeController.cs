using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarFleetMS.Models;

namespace CarFleetMS.Controllers
{
    public class HomeController : Controller
    {
        CarFleetMSContext _context = new CarFleetMSContext();
        public IActionResult Index()
        {
            _context.Vehicle.ToList();
            _context.Brand.ToList();
            return View();
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
