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

            List<Ensurance> ensuranceList = _context.Ensurance.ToList();
            List<TechnicalExamination> techList = _context.TechnicalExamination.ToList();

            List<Ensurance> ensFinal = _context.Ensurance.ToList();
            List<TechnicalExamination> techFinal = _context.TechnicalExamination.ToList();


            foreach (Ensurance ens1 in ensuranceList)
            {
                foreach (Ensurance ens2 in ensuranceList)
                {
                    if(ens1.VehicleId.Equals(ens2.VehicleId) && DateTime.Compare(ens1.EndDate, ens2.EndDate) > 0)
                    {
                        ensFinal.Remove(ens2);
                    }
                }
            }

            foreach(TechnicalExamination tech1 in techList)
            {
                foreach(TechnicalExamination tech2 in techList)
                {
                    if (tech1.VehicleId.Equals(tech2.VehicleId) && DateTime.Compare(tech1.Validity, tech2.Validity) > 0)
                    {
                        techFinal.Remove(tech2);
                    }
                }
            }

            VehicleViewModel vehicleViewModel = new VehicleViewModel
            {
                Vehicles = _context.Vehicle,
                Brands = _context.Brand,
                Models = _context.Model,
                Ensurances = ensFinal,
                TechnicalExaminations = techFinal
            };




            //return View(await carFleetMSContext.ToListAsync());
            return View(vehicleViewModel);
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

        public async Task<IActionResult> DetailsVehicle(int? id)
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

            VehicleViewModel vehicleViewModel = new VehicleViewModel
            {
                Vehicles = _context.Vehicle,
                Brands = _context.Brand,
                Models = _context.Model,
                TechnicalExaminations = _context.TechnicalExamination
            };

            AddVehicleViewModel vm = Model();

            //vm.Vehicle.VehicleId(id)

            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        //----------------------------------------------------------

        public async Task<IActionResult> EditVehicle(int? id)
        {
            var vehicle = _context.Vehicle.FirstOrDefault(v => v.VehicleId == id);

            AddVehicleViewModel vm = Model();
            vm.Vehicle = vehicle;



            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditVehicle(int id, [Bind("VehicleId,RegistrationNumber,DateOfFirstRegistration,Vin,MaxVehicleMass,PermissibleGrossVehicleWeight,PermissibleTotalWeightOfTheVehicleCombination,VehicleMass,RegistrationEndDate,RegistrationReleaseDate,VehicleTypeApprovalCertificateNumber,AxlesNumber,MaxTrailerWeightWithBrake,MaxTrailerWeightWithoutBrake,EngineCapacity,MaxNetPowerOfTheEngine,PowerToWeightRatio,SeatsNumber,StandingPositionsNumber,Purpose,YearOfProduction,MaxCapacity,MaxAxleLoad,CardNumber,OwnerId,HolderId,ModelId,VehicleTypeId,VehicleCategoryId,FuelTypeId,VehicleKindId")] Vehicle vehicle)
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
            return View(Model());
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

        //--------------------------------------------------------------

        public IActionResult AddVehicle()
        {
            return View(Model());
        }

        public AddVehicleViewModel Model()
        {
            var people = _context.PersonCompany.ToList();
            var brands = _context.Brand.ToList();
            var models = _context.Model.ToList();
            var vehicleTypes = _context.VehicleType.ToList();
            var vehicleCategories = _context.VehicleCategory.ToList();
            var fuelTypes = _context.FuelType.ToList();
            var vehicleKinds = _context.VehicleKind.ToList();

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

            return vm;
        }

        [HttpPost]
        public IActionResult AddVehicle([Bind("VehicleId,RegistrationNumber,DateOfFirstRegistration,Vin,MaxVehicleMass,PermissibleGrossVehicleWeight,PermissibleTotalWeightOfTheVehicleCombination,VehicleMass,RegistrationEndDate,RegistrationReleaseDate,VehicleTypeApprovalCertificateNumber,AxlesNumber,MaxTrailerWeightWithBrake,MaxTrailerWeightWithoutBrake,EngineCapacity,MaxNetPowerOfTheEngine,PowerToWeightRatio,SeatsNumber,StandingPositionsNumber,Purpose,YearOfProduction,MaxCapacity,MaxAxleLoad,CardNumber,OwnerId,HolderId,ModelId,VehicleTypeId,VehicleCategoryId,FuelTypeId,VehicleKindId")] Vehicle vehicle)
        {
            _context.Add(vehicle);
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult FindModels(int id)
        {
            var list = _context.Model.Where(model => model.BrandId == id).Select(model => new
            {
                id = model.ModelId,
                name = model.Name
            }).ToList();

            return new JsonResult(list);
        }
    }
}
