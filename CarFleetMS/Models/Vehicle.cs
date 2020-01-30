using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarFleetMS.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Ensurance = new HashSet<Ensurance>();
            Invoice = new HashSet<Invoice>();
            Repair = new HashSet<Repair>();
            TechnicalExamination = new HashSet<TechnicalExamination>();
            VehicleAnnotations = new HashSet<VehicleAnnotations>();
            VehicleDriver = new HashSet<VehicleDriver>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleId { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime DateOfFirstRegistration { get; set; }
        //public string Type { get; set; }//string Type after that line
        public string Vin { get; set; }
        public int MaxVehicleMass { get; set; }
        public int PermissibleGrossVehicleWeight { get; set; }
        public int PermissibleTotalWeightOfTheVehicleCombination { get; set; }
        public int VehicleMass { get; set; }
        public DateTime RegistrationEndDate { get; set; }
        public DateTime RegistrationReleaseDate { get; set; }
        public string VehicleTypeApprovalCertificateNumber { get; set; }
        public int AxlesNumber { get; set; }
        public int MaxTrailerWeightWithBrake { get; set; }
        public int MaxTrailerWeightWithoutBrake { get; set; }
        public double EngineCapacity { get; set; }
        public double MaxNetPowerOfTheEngine { get; set; }
        //public string FuelType { get; set; }
        public int PowerToWeightRatio { get; set; }
        public int SeatsNumber { get; set; }
        public int? StandingPositionsNumber { get; set; }
        public string Purpose { get; set; } //int b4
        public int YearOfProduction { get; set; }
        public int MaxCapacity { get; set; }
        public double MaxAxleLoad { get; set; }
        public string CardNumber { get; set; } //int b4
        public int OwnerId { get; set; }
        public int HolderId { get; set; }
        public int ModelId { get; set; }
        public int VehicleTypeId { get; set; }
        public int VehicleCategoryId { get; set; }
        public int FuelTypeId { get; set; }
        public int VehicleKindId { get; set; }
        public int InstitutionId { get; set; }

        public Institution Institution { get; set; }
        public VehicleKind VehicleKind { get; set; }
        public FuelType FuelType { get; set; }
        public PersonCompany Holder { get; set; }
        public Model Model { get; set; }
        public PersonCompany Owner { get; set; }
        public VehicleCategory VehicleCategory { get; set; }
        public VehicleType VehicleType { get; set; }
        public ICollection<Ensurance> Ensurance { get; set; }
        public ICollection<Invoice> Invoice { get; set; }
        public ICollection<Repair> Repair { get; set; }
        public ICollection<TechnicalExamination> TechnicalExamination { get; set; }
        public ICollection<VehicleAnnotations> VehicleAnnotations { get; set; }
        public ICollection<VehicleDriver> VehicleDriver { get; set; }
    }
}
