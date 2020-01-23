using CarFleetMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarFleetMS.Data.ViewModel
{
    public class AddPersonViewModel
    {
        public PersonCompany People { get; set; }
        public List<SelectListItem> Addresses { get; set; }

    }
}
