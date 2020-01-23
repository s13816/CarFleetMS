using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarFleetMS.Models;
using CarFleetMS.Data.ViewModel;

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

        public IActionResult AddPerson()
        {
            return View(Model());
        }

        [HttpPost]
        public IActionResult AddPerson([Bind("PersonId,Name,SecondName,Surname,Pesel,CompanyName,NIP,PhoneNumber,Email,IsPerson,AddressId")] PersonCompany personCompany)
        {
            _context.Add(personCompany);
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        // GET: Names/Edit/5
        //The GET method takes the id from the URL and passes it into the query to 

        //return data for the specific record
        public ActionResult EditPerson(int id)
        {
            //You don't need the joins since you have navigation properies!
            var personCompany = _context.PersonCompany.FirstOrDefault(n => n.PersonId == id);
            var addresses = _context.Address.ToList();
            EditPersonViewModel model;

            List<SelectListItem> sliAddresses = new List<SelectListItem>();

            foreach (Address address in addresses)
            {
                var text = "";
                if (address.ApartmentNumber != null)
                {
                    text = address.City + " ul. " + address.Street + " " + address.BuildingNumber + " / " + address.ApartmentNumber;
                }
                else
                {
                    text = address.City + " ul. " + address.Street + " " + address.BuildingNumber;
                }
                sliAddresses.Add(new SelectListItem { Value = address.AddressId.ToString(), Text = text });
            }


            if (personCompany == default(PersonCompany))
            {
                model = new EditPersonViewModel
                {
                    Addresses = sliAddresses
                };
            }
            else
            {
                model = new EditPersonViewModel
                {
                    PersonId = personCompany.PersonId,
                    Name = personCompany.Name,
                    SecondName = personCompany.SecondName,
                    Surname = personCompany.Surname,
                    Pesel = personCompany.Pesel,
                    CompanyName = personCompany.CompanyName,
                    NIP = personCompany.NIP,
                    PhoneNumber = personCompany.PhoneNumber,
                    Email = personCompany.Email,
                    IsPerson = personCompany.IsPerson,
                    AddressId = personCompany.AddressId,
                    Address = personCompany.Address,
                    Addresses = sliAddresses
                };
            }
            //if (!model.Addresses.Any())
            //{
            //    model.Addresses.Add(new Address());
            //}
            //Returns the query to the view
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPerson(EditPersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Query the database for the row to be updated. 
                var personCompany = _context.PersonCompany.FirstOrDefault(n => n.PersonId == model.PersonId);
                if (personCompany != default(PersonCompany))
                {
                    personCompany.Name = model.Name;
                    personCompany.SecondName = model.SecondName;
                    personCompany.Surname = model.Surname;
                    personCompany.Pesel = model.Pesel;
                    personCompany.CompanyName = model.CompanyName;
                    personCompany.NIP = model.NIP;
                    personCompany.PhoneNumber = model.PhoneNumber;
                    personCompany.Email = model.Email;
                    personCompany.IsPerson = model.IsPerson;
                    personCompany.AddressId = model.AddressId;
                    personCompany.Address = model.Address;

                    _context.SaveChangesAsync();

                }
            }
            return RedirectToAction("Index");
        }




        //-----------------------------------------------

        public AddPersonViewModel Model()
        {
            var people = _context.PersonCompany.ToList();
            var addresses = _context.Address.ToList();

            List<SelectListItem> sliPeople = new List<SelectListItem>();
            List<SelectListItem> sliAddresses = new List<SelectListItem>();


            foreach (PersonCompany person in people)
            {
                if (person.IsPerson)
                {
                    sliPeople.Add(new SelectListItem { Value = person.PersonId.ToString(), Text = person.Name + " " + person.Surname });
                }
                else
                {
                    sliPeople.Add(new SelectListItem { Value = person.PersonId.ToString(), Text = person.CompanyName });
                }

            }

            foreach (Address address in addresses)
            {
                var text = "";
                if (address.ApartmentNumber != null)
                {
                    text = address.City + " ul. " + address.Street + " " + address.BuildingNumber + " / " + address.ApartmentNumber;
                }
                else
                {
                    text = address.City + " ul. " + address.Street + " " + address.BuildingNumber;
                }
                sliAddresses.Add(new SelectListItem { Value = address.AddressId.ToString(), Text = text });
            }


            AddPersonViewModel vm = new AddPersonViewModel()
            {
                Addresses = sliAddresses
            };

            return vm;
        }
    }
}
