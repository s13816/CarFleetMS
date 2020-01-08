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
    public class EnsurancesController : Controller
    {
        private readonly CarFleetMSContext _context;

        public EnsurancesController(CarFleetMSContext context)
        {
            _context = context;
        }

        // GET: Ensurances
        public async Task<IActionResult> Index()
        {
            var carFleetMSContext = _context.Ensurance.Include(e => e.PersonCompany).Include(e => e.Vehicle);
            return View(await carFleetMSContext.ToListAsync());
        }

        // GET: Ensurances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ensurance = await _context.Ensurance
                .Include(e => e.PersonCompany)
                .Include(e => e.Vehicle)
                .FirstOrDefaultAsync(m => m.EnsuranceId == id);
            if (ensurance == null)
            {
                return NotFound();
            }

            return View(ensurance);
        }

        // GET: Ensurances/Create
        public IActionResult Create()
        {
            ViewData["PersonCompanyId"] = new SelectList(_context.PersonCompany, "PersonId", "PersonId");
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "VehicleId", "RegistrationNumber");
            return View();
        }

        // POST: Ensurances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnsuranceId,EnsuranceNumber,NameOfTheCompany,StartDate,EndDate,Amount,VehicleId,PersonCompanyId")] Ensurance ensurance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ensurance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonCompanyId"] = new SelectList(_context.PersonCompany, "PersonId", "PersonId", ensurance.PersonCompanyId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "VehicleId", "RegistrationNumber", ensurance.VehicleId);
            return View(ensurance);
        }

        // GET: Ensurances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ensurance = await _context.Ensurance.FindAsync(id);
            if (ensurance == null)
            {
                return NotFound();
            }
            ViewData["PersonCompanyId"] = new SelectList(_context.PersonCompany, "PersonId", "PersonId", ensurance.PersonCompanyId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "VehicleId", "RegistrationNumber", ensurance.VehicleId);
            return View(ensurance);
        }

        // POST: Ensurances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnsuranceId,EnsuranceNumber,NameOfTheCompany,StartDate,EndDate,Amount,VehicleId,PersonCompanyId")] Ensurance ensurance)
        {
            if (id != ensurance.EnsuranceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ensurance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnsuranceExists(ensurance.EnsuranceId))
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
            ViewData["PersonCompanyId"] = new SelectList(_context.PersonCompany, "PersonId", "PersonId", ensurance.PersonCompanyId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "VehicleId", "RegistrationNumber", ensurance.VehicleId);
            return View(ensurance);
        }

        // GET: Ensurances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ensurance = await _context.Ensurance
                .Include(e => e.PersonCompany)
                .Include(e => e.Vehicle)
                .FirstOrDefaultAsync(m => m.EnsuranceId == id);
            if (ensurance == null)
            {
                return NotFound();
            }

            return View(ensurance);
        }

        // POST: Ensurances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ensurance = await _context.Ensurance.FindAsync(id);
            _context.Ensurance.Remove(ensurance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnsuranceExists(int id)
        {
            return _context.Ensurance.Any(e => e.EnsuranceId == id);
        }
    }
}
