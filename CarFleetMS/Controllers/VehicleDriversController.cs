using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarFleetMS.Models;

namespace CarFleetMS.Controllers
{
    public class VehicleDriversController : Controller
    {
        private readonly CarFleetMSContext _context;

        public VehicleDriversController(CarFleetMSContext context)
        {
            _context = context;
        }

        // GET: VehicleDrivers
        public async Task<IActionResult> Index()
        {
            var carFleetMSContext = _context.VehicleDriver.Include(v => v.Driver).Include(v => v.Vehicle);
            return View(await carFleetMSContext.ToListAsync());
        }

        // GET: VehicleDrivers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleDriver = await _context.VehicleDriver
                .Include(v => v.Driver)
                .Include(v => v.Vehicle)
                .FirstOrDefaultAsync(m => m.VehicleDriverId == id);
            if (vehicleDriver == null)
            {
                return NotFound();
            }

            return View(vehicleDriver);
        }

        // GET: VehicleDrivers/Create
        public IActionResult Create()
        {
            ViewData["DriverId"] = new SelectList(_context.Driver, "DriverId", "DriverId");
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "VehicleId", "RegistrationNumber");
            return View();
        }

        // POST: VehicleDrivers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleDriverId,VehicleId,DriverId")] VehicleDriver vehicleDriver)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleDriver);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DriverId"] = new SelectList(_context.Driver, "DriverId", "DriverId", vehicleDriver.DriverId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "VehicleId", "RegistrationNumber", vehicleDriver.VehicleId);
            return View(vehicleDriver);
        }

        // GET: VehicleDrivers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleDriver = await _context.VehicleDriver.FindAsync(id);
            if (vehicleDriver == null)
            {
                return NotFound();
            }
            ViewData["DriverId"] = new SelectList(_context.Driver, "DriverId", "DriverId", vehicleDriver.DriverId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "VehicleId", "RegistrationNumber", vehicleDriver.VehicleId);
            return View(vehicleDriver);
        }

        // POST: VehicleDrivers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleDriverId,VehicleId,DriverId")] VehicleDriver vehicleDriver)
        {
            if (id != vehicleDriver.VehicleDriverId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleDriver);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleDriverExists(vehicleDriver.VehicleDriverId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DriverId"] = new SelectList(_context.Driver, "DriverId", "DriverId", vehicleDriver.DriverId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "VehicleId", "RegistrationNumber", vehicleDriver.VehicleId);
            return View(vehicleDriver);
        }

        // GET: VehicleDrivers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleDriver = await _context.VehicleDriver
                .Include(v => v.Driver)
                .Include(v => v.Vehicle)
                .FirstOrDefaultAsync(m => m.VehicleDriverId == id);
            if (vehicleDriver == null)
            {
                return NotFound();
            }

            return View(vehicleDriver);
        }

        // POST: VehicleDrivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleDriver = await _context.VehicleDriver.FindAsync(id);
            _context.VehicleDriver.Remove(vehicleDriver);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleDriverExists(int id)
        {
            return _context.VehicleDriver.Any(e => e.VehicleDriverId == id);
        }
    }
}
