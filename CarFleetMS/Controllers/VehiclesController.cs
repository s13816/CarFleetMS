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
    public class VehiclesController : Controller
    {
        private readonly CarFleetMSContext _context;

        public VehiclesController(CarFleetMSContext context)
        {
            _context = context;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            var carFleetMSContext = _context.Vehicle.Include(v => v.FuelType).Include(v => v.Holder).Include(v => v.Model).Include(v => v.Owner).Include(v => v.VehicleCategory).Include(v => v.VehicleKind).Include(v => v.VehicleType);
            return View(await carFleetMSContext.ToListAsync());
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .Include(v => v.FuelType)
                .Include(v => v.Holder)
                .Include(v => v.Model)
                .Include(v => v.Owner)
                .Include(v => v.VehicleCategory)
                .Include(v => v.VehicleKind)
                .Include(v => v.VehicleType)
                .FirstOrDefaultAsync(m => m.VehicleId == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            ViewData["FuelTypeId"] = new SelectList(_context.FuelType, "FuelTypeId", "FuelTypeId");
            ViewData["HolderId"] = new SelectList(_context.PersonCompany, "PersonId", "PersonId");
            ViewData["ModelId"] = new SelectList(_context.Model, "ModelId", "Name");
            ViewData["OwnerId"] = new SelectList(_context.PersonCompany, "PersonId", "PersonId");
            ViewData["VehicleCategoryId"] = new SelectList(_context.VehicleCategory, "VehicleCategoryId", "VehicleCategoryId");
            ViewData["VehicleKindId"] = new SelectList(_context.VehicleKind, "VehicleKindId", "VehicleKindId");
            ViewData["VehicleTypeId"] = new SelectList(_context.VehicleType, "VehicleTypeId", "VehicleTypeId");
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleId,RegistrationNumber,DateOfFirstRegistration,Vin,MaxVehicleMass,PermissibleGrossVehicleWeight,PermissibleTotalWeightOfTheVehicleCombination,VehicleMass,RegistrationEndDate,RegistrationReleaseDate,VehicleTypeApprovalCertificateNumber,AxlesNumber,MaxTrailerWeightWithBrake,MaxTrailerWeightWithoutBrake,EngineCapacity,MaxNetPowerOfTheEngine,PowerToWeightRatio,SeatsNumber,StandingPositionsNumber,Purpose,YearOfProduction,MaxCapacity,MaxAxleLoad,CardNumber,OwnerId,HolderId,ModelId,VehicleTypeId,VehicleCategoryId,FuelTypeId,VehicleKindId")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FuelTypeId"] = new SelectList(_context.FuelType, "FuelTypeId", "FuelTypeId", vehicle.FuelTypeId);
            ViewData["HolderId"] = new SelectList(_context.PersonCompany, "PersonId", "PersonId", vehicle.HolderId);
            ViewData["ModelId"] = new SelectList(_context.Model, "ModelId", "Name", vehicle.ModelId);
            ViewData["OwnerId"] = new SelectList(_context.PersonCompany, "PersonId", "PersonId", vehicle.OwnerId);
            ViewData["VehicleCategoryId"] = new SelectList(_context.VehicleCategory, "VehicleCategoryId", "VehicleCategoryId", vehicle.VehicleCategoryId);
            ViewData["VehicleKindId"] = new SelectList(_context.VehicleKind, "VehicleKindId", "VehicleKindId", vehicle.VehicleKindId);
            ViewData["VehicleTypeId"] = new SelectList(_context.VehicleType, "VehicleTypeId", "VehicleTypeId", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            ViewData["FuelTypeId"] = new SelectList(_context.FuelType, "FuelTypeId", "FuelTypeId", vehicle.FuelTypeId);
            ViewData["HolderId"] = new SelectList(_context.PersonCompany, "PersonId", "PersonId", vehicle.HolderId);
            ViewData["ModelId"] = new SelectList(_context.Model, "ModelId", "Name", vehicle.ModelId);
            ViewData["OwnerId"] = new SelectList(_context.PersonCompany, "PersonId", "PersonId", vehicle.OwnerId);
            ViewData["VehicleCategoryId"] = new SelectList(_context.VehicleCategory, "VehicleCategoryId", "VehicleCategoryId", vehicle.VehicleCategoryId);
            ViewData["VehicleKindId"] = new SelectList(_context.VehicleKind, "VehicleKindId", "VehicleKindId", vehicle.VehicleKindId);
            ViewData["VehicleTypeId"] = new SelectList(_context.VehicleType, "VehicleTypeId", "VehicleTypeId", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleId,RegistrationNumber,DateOfFirstRegistration,Vin,MaxVehicleMass,PermissibleGrossVehicleWeight,PermissibleTotalWeightOfTheVehicleCombination,VehicleMass,RegistrationEndDate,RegistrationReleaseDate,VehicleTypeApprovalCertificateNumber,AxlesNumber,MaxTrailerWeightWithBrake,MaxTrailerWeightWithoutBrake,EngineCapacity,MaxNetPowerOfTheEngine,PowerToWeightRatio,SeatsNumber,StandingPositionsNumber,Purpose,YearOfProduction,MaxCapacity,MaxAxleLoad,CardNumber,OwnerId,HolderId,ModelId,VehicleTypeId,VehicleCategoryId,FuelTypeId,VehicleKindId")] Vehicle vehicle)
        {
            if (id != vehicle.VehicleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.VehicleId))
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
            ViewData["FuelTypeId"] = new SelectList(_context.FuelType, "FuelTypeId", "FuelTypeId", vehicle.FuelTypeId);
            ViewData["HolderId"] = new SelectList(_context.PersonCompany, "PersonId", "PersonId", vehicle.HolderId);
            ViewData["ModelId"] = new SelectList(_context.Model, "ModelId", "Name", vehicle.ModelId);
            ViewData["OwnerId"] = new SelectList(_context.PersonCompany, "PersonId", "PersonId", vehicle.OwnerId);
            ViewData["VehicleCategoryId"] = new SelectList(_context.VehicleCategory, "VehicleCategoryId", "VehicleCategoryId", vehicle.VehicleCategoryId);
            ViewData["VehicleKindId"] = new SelectList(_context.VehicleKind, "VehicleKindId", "VehicleKindId", vehicle.VehicleKindId);
            ViewData["VehicleTypeId"] = new SelectList(_context.VehicleType, "VehicleTypeId", "VehicleTypeId", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .Include(v => v.FuelType)
                .Include(v => v.Holder)
                .Include(v => v.Model)
                .Include(v => v.Owner)
                .Include(v => v.VehicleCategory)
                .Include(v => v.VehicleKind)
                .Include(v => v.VehicleType)
                .FirstOrDefaultAsync(m => m.VehicleId == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicle = await _context.Vehicle.FindAsync(id);
            _context.Vehicle.Remove(vehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicle.Any(e => e.VehicleId == id);
        }

        public IActionResult AddVehicle()
        {
            var people = _context.PersonCompany.ToList();
            var brands = _context.Brand.ToList();
            var models = _context.Model.ToList();
            var vehicleTypes = _context.VehicleType.ToList();
            var vehicleCategories = _context.VehicleCategory.ToList();
            var fuelTypes = _context.FuelType.ToList();
            var vehicleKinds = _context.VehicleKind.ToList();

            ViewBag.brands = _context.Brand.ToList(); ;
            ViewBag.models = _context.Model.ToList();
            List<SelectListItem> sliPeople = new List<SelectListItem>();
            List<SelectListItem> sliBrands = new List<SelectListItem>();
            List<SelectListItem> sliVehicleTypes = new List<SelectListItem>();
            List<SelectListItem> sliVehicleCategories = new List<SelectListItem>();
            List<SelectListItem> sliModels = new List<SelectListItem>();
            List<SelectListItem> sliFuelTypes = new List<SelectListItem>();
            List<SelectListItem> sliVehicleKinds = new List<SelectListItem>();


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

            foreach (Brand brand in brands)
            {
                sliBrands.Add(new SelectListItem { Value = brand.BrandId.ToString(), Text = brand.Name });
            }

            foreach (Model model in models)
            {
                sliModels.Add(new SelectListItem { Value = model.ModelId.ToString(), Text = model.Name });
            }

            foreach (VehicleType vehicleType in vehicleTypes)
            {
                sliVehicleTypes.Add(new SelectListItem { Value = vehicleType.VehicleTypeId.ToString(), Text = vehicleType.Variant + "\n" + vehicleType.Version });
            }

            foreach (VehicleCategory vehicleCategory in vehicleCategories)
            {
                sliVehicleCategories.Add(new SelectListItem { Value = vehicleCategory.VehicleCategoryId.ToString(), Text = vehicleCategory.Name });
            }

            foreach (FuelType fuelType in fuelTypes)
            {
                sliFuelTypes.Add(new SelectListItem { Value = fuelType.FuelTypeId.ToString(), Text = fuelType.Name });
            }

            foreach (VehicleKind vehicleKind in vehicleKinds)
            {
                sliVehicleKinds.Add(new SelectListItem { Value = vehicleKind.VehicleKindId.ToString(), Text = vehicleKind.Name });
            }

            AddVehicleViewModel vm = new AddVehicleViewModel()
            {
                People = sliPeople,
                Brands = sliBrands,
                VehicleTypes = sliVehicleTypes,
                Models = sliModels,
                VehicleCategories = sliVehicleCategories,
                FuelTypes = sliFuelTypes,
                VehicleKinds = sliVehicleKinds
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult AddVehicle(Vehicle vehicle)
        {
            _context.Vehicle.Add(vehicle);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult FindModels(int id)
        {

            //var list = _context.Model.Where(m => m.BrandId == id).ToList();
            var lista = _context.Brand.ToList();
            var list = _context.Model.Where(model => model.BrandId == id).Select(model => new
            {
                id = model.ModelId,
                name = model.Name
            }).ToList();


            return new JsonResult(list);
            //return View(_context.Vehicle.ToList());
        }
    }
}
