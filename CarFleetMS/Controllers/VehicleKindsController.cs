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
    public class VehicleKindsController : Controller
    {
        private readonly CarFleetMSContext _context;

        public VehicleKindsController(CarFleetMSContext context)
        {
            _context = context;
        }

        // GET: VehicleKinds
        public async Task<IActionResult> Index()
        {
            return View(await _context.VehicleKind.ToListAsync());
        }

        // GET: VehicleKinds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleKind = await _context.VehicleKind
                .FirstOrDefaultAsync(m => m.VehicleKindId == id);
            if (vehicleKind == null)
            {
                return NotFound();
            }

            return View(vehicleKind);
        }

        // GET: VehicleKinds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleKinds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleKindId,Name")] VehicleKind vehicleKind)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleKind);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleKind);
        }

        // GET: VehicleKinds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleKind = await _context.VehicleKind.FindAsync(id);
            if (vehicleKind == null)
            {
                return NotFound();
            }
            return View(vehicleKind);
        }

        // POST: VehicleKinds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleKindId,Name")] VehicleKind vehicleKind)
        {
            if (id != vehicleKind.VehicleKindId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleKind);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleKindExists(vehicleKind.VehicleKindId))
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
            return View(vehicleKind);
        }

        // GET: VehicleKinds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleKind = await _context.VehicleKind
                .FirstOrDefaultAsync(m => m.VehicleKindId == id);
            if (vehicleKind == null)
            {
                return NotFound();
            }

            return View(vehicleKind);
        }

        // POST: VehicleKinds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleKind = await _context.VehicleKind.FindAsync(id);
            _context.VehicleKind.Remove(vehicleKind);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleKindExists(int id)
        {
            return _context.VehicleKind.Any(e => e.VehicleKindId == id);
        }
    }
}
