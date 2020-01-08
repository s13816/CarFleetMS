﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarFleetMS.Models
{
    public partial class Driver
    {
        public Driver()
        {
            VehicleDriver = new HashSet<VehicleDriver>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DriverId { get; set; }
        public int PersonCompanyId { get; set; }

        public PersonCompany PersonCompany { get; set; }
        public ICollection<VehicleDriver> VehicleDriver { get; set; }
    }
}
