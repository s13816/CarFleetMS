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
    public class VehicleAnnotationsController : Controller
    {
        private readonly CarFleetMSContext _context;

        public VehicleAnnotationsController(CarFleetMSContext context)
        {
            _context = context;
        }

        // GET: VehicleAnnotations
        public async Task<IActionResult> Index()
        {
            var carFleetMSContext = _context.VehicleAnnotations.Include(v => v.Vehicle);
            return View(await carFleetMSContext.ToListAsync());
        }

        // GET: VehicleAnnotations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleAnnotations = await _context.VehicleAnnotations
                .Include(v => v.Vehicle)
                .FirstOrDefaultAsync(m => m.VehicleAnnotationId == id);
            if (vehicleAnnotations == null)
            {
                return NotFound();
            }

            return View(vehicleAnnotations);
        }

        // GET: VehicleAnnotations/Create
        public IActionResult Create()
        {
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "VehicleId", "RegistrationNumber");
            return View();
        }

        // POST: VehicleAnnotations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleAnnotationId,Content,Date,VehicleId")] VehicleAnnotations vehicleAnnotations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleAnnotations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "VehicleId", "RegistrationNumber", vehicleAnnotations.VehicleId);
            return View(vehicleAnnotations);
        }

        // GET: VehicleAnnotations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleAnnotations = await _context.VehicleAnnotations.FindAsync(id);
            if (vehicleAnnotations == null)
            {
                return NotFound();
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "VehicleId", "RegistrationNumber", vehicleAnnotations.VehicleId);
            return View(vehicleAnnotations);
        }

        // POST: VehicleAnnotations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleAnnotationId,Content,Date,VehicleId")] VehicleAnnotations vehicleAnnotations)
        {
            if (id != vehicleAnnotations.VehicleAnnotationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleAnnotations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleAnnotationsExists(vehicleAnnotations.VehicleAnnotationId))
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
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "VehicleId", "RegistrationNumber", vehicleAnnotations.VehicleId);
            return View(vehicleAnnotations);
        }

        // GET: VehicleAnnotations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleAnnotations = await _context.VehicleAnnotations
                .Include(v => v.Vehicle)
                .FirstOrDefaultAsync(m => m.VehicleAnnotationId == id);
            if (vehicleAnnotations == null)
            {
                return NotFound();
            }

            return View(vehicleAnnotations);
        }

        // POST: VehicleAnnotations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleAnnotations = await _context.VehicleAnnotations.FindAsync(id);
            _context.VehicleAnnotations.Remove(vehicleAnnotations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleAnnotationsExists(int id)
        {
            return _context.VehicleAnnotations.Any(e => e.VehicleAnnotationId == id);
        }
    }
}
