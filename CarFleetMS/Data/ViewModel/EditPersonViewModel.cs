using CarFleetMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarFleetMS.Data.ViewModel
{
    public class EditPersonViewModel
    {
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
        public List<SelectListItem> Addresses { get; set; }
    }
}
