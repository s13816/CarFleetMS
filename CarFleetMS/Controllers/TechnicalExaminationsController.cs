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
    public class TechnicalExaminationsController : Controller
    {
        private readonly CarFleetMSContext _context;

        public TechnicalExaminationsController(CarFleetMSContext context)
        {
            _context = context;
        }

        // GET: TechnicalExaminations
        public async Task<IActionResult> Index()
        {
            var carFleetMSContext = _context.TechnicalExamination.Include(t => t.Vehicle);
            return View(await carFleetMSContext.ToListAsync());
        }

        // GET: TechnicalExaminations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technicalExamination = await _context.TechnicalExamination
                .Include(t => t.Vehicle)
                .FirstOrDefaultAsync(m => m.ServiceId == id);
            if (technicalExamination == null)
            {
                return NotFound();
            }

            return View(technicalExamination);
        }

        // GET: TechnicalExaminations/Create
        public IActionResult Create()
        {
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "VehicleId", "RegistrationNumber");
            return View();
        }

        // POST: TechnicalExaminations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceId,DateOfExam,Validity,VehicleId")] TechnicalExamination technicalExamination)
        {
            if (ModelState.IsValid)
            {
                _context.Add(technicalExamination);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "VehicleId", "RegistrationNumber", technicalExamination.VehicleId);
            return View(technicalExamination);
        }

        // GET: TechnicalExaminations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technicalExamination = await _context.TechnicalExamination.FindAsync(id);
            if (technicalExamination == null)
            {
                return NotFound();
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "VehicleId", "RegistrationNumber", technicalExamination.VehicleId);
            return View(technicalExamination);
        }

        // POST: TechnicalExaminations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceId,DateOfExam,Validity,VehicleId")] TechnicalExamination technicalExamination)
        {
            if (id != technicalExamination.ServiceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(technicalExamination);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TechnicalExaminationExists(technicalExamination.ServiceId))
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
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "VehicleId", "RegistrationNumber", technicalExamination.VehicleId);
            return View(technicalExamination);
        }

        // GET: TechnicalExaminations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technicalExamination = await _context.TechnicalExamination
                .Include(t => t.Vehicle)
                .FirstOrDefaultAsync(m => m.ServiceId == id);
            if (technicalExamination == null)
            {
                return NotFound();
            }

            return View(technicalExamination);
        }

        // POST: TechnicalExaminations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var technicalExamination = await _context.TechnicalExamination.FindAsync(id);
            _context.TechnicalExamination.Remove(technicalExamination);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TechnicalExaminationExists(int id)
        {
            return _context.TechnicalExamination.Any(e => e.ServiceId == id);
        }
    }
}
