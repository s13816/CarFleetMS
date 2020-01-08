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
    public class VehicleCategoriesController : Controller
    {
        private readonly CarFleetMSContext _context;

        public VehicleCategoriesController(CarFleetMSContext context)
        {
            _context = context;
        }

        // GET: VehicleCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.VehicleCategory.ToListAsync());
        }

        // GET: VehicleCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleCategory = await _context.VehicleCategory
                .FirstOrDefaultAsync(m => m.VehicleCategoryId == id);
            if (vehicleCategory == null)
            {
                return NotFound();
            }

            return View(vehicleCategory);
        }

        // GET: VehicleCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleCategoryId,Name")] VehicleCategory vehicleCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleCategory);
        }

        // GET: VehicleCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleCategory = await _context.VehicleCategory.FindAsync(id);
            if (vehicleCategory == null)
            {
                return NotFound();
            }
            return View(vehicleCategory);
        }

        // POST: VehicleCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleCategoryId,Name")] VehicleCategory vehicleCategory)
        {
            if (id != vehicleCategory.VehicleCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleCategoryExists(vehicleCategory.VehicleCategoryId))
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
            return View(vehicleCategory);
        }

        // GET: VehicleCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleCategory = await _context.VehicleCategory
                .FirstOrDefaultAsync(m => m.VehicleCategoryId == id);
            if (vehicleCategory == null)
            {
                return NotFound();
            }

            return View(vehicleCategory);
        }

        // POST: VehicleCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleCategory = await _context.VehicleCategory.FindAsync(id);
            _context.VehicleCategory.Remove(vehicleCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleCategoryExists(int id)
        {
            return _context.VehicleCategory.Any(e => e.VehicleCategoryId == id);
        }
    }
}
