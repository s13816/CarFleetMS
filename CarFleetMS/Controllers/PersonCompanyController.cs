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
    public class PersonCompanyController : Controller
    {
        private readonly CarFleetMSContext _context;

        public PersonCompanyController(CarFleetMSContext context)
        {
            _context = context;
        }

        // GET: PersonCompany
        public async Task<IActionResult> Index()
        {
            var carFleetMSContext = _context.PersonCompany.Include(p => p.Address);
            return View(await carFleetMSContext.ToListAsync());
        }

        // GET: PersonCompany/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personCompany = await _context.PersonCompany
                .Include(p => p.Address)
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (personCompany == null)
            {
                return NotFound();
            }

            return View(personCompany);
        }

        // GET: PersonCompany/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Address, "AddressId", "AddressId");
            return View();
        }

        // POST: PersonCompany/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonId,Name,SecondName,Surname,Pesel,CompanyName,NIP,PhoneNumber,Email,IsPerson,AddressId")] PersonCompany personCompany)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personCompany);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Address, "AddressId", "AddressId", personCompany.AddressId);
            return View(personCompany);
        }

        // GET: PersonCompany/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personCompany = await _context.PersonCompany.FindAsync(id);
            if (personCompany == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Address, "AddressId", "AddressId", personCompany.AddressId);
            return View(personCompany);
        }

        // POST: PersonCompany/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonId,Name,SecondName,Surname,Pesel,CompanyName,NIP,PhoneNumber,Email,IsPerson,AddressId")] PersonCompany personCompany)
        {
            if (id != personCompany.PersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personCompany);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonCompanyExists(personCompany.PersonId))
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
            ViewData["AddressId"] = new SelectList(_context.Address, "AddressId", "AddressId", personCompany.AddressId);
            return View(personCompany);
        }

        // GET: PersonCompany/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personCompany = await _context.PersonCompany
                .Include(p => p.Address)
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (personCompany == null)
            {
                return NotFound();
            }

            return View(personCompany);
        }

        // POST: PersonCompany/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personCompany = await _context.PersonCompany.FindAsync(id);
            _context.PersonCompany.Remove(personCompany);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonCompanyExists(int id)
        {
            return _context.PersonCompany.Any(e => e.PersonId == id);
        }
    }
}
