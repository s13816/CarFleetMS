using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarFleetMS.Models
{
    public partial class PersonCompany
    {
        public PersonCompany()
        {
            Driver = new HashSet<Driver>();
            Ensurance = new HashSet<Ensurance>();
            VehicleHolder = new HashSet<Vehicle>();
            VehicleOwner = new HashSet<Vehicle>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string Pesel { get; set; }
        public string CompanyName { get; set; }
        public string NIP { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsPerson { get; set; }
        public int AddressId { get; set; }

        public Address Address { get; set; }
        public ICollection<Driver> Driver { get; set; }
        public ICollection<Ensurance> Ensurance { get; set; }
        public ICollection<Vehicle> VehicleHolder { get; set; }
        public ICollection<Vehicle> VehicleOwner { get; set; }
    }
}
