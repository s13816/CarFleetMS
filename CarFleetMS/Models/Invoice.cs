using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarFleetMS.Models
{
    public partial class Invoice
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FuelInvoiceId { get; set; }
        public int VehicleId { get; set; }
        public string InvoiceNumber { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
