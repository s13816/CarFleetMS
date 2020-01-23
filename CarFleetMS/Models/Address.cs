using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarFleetMS.Models
{
    public partial class Address
    {
        public Address()
        {
            PersonCompany = new HashSet<PersonCompany>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        [ForeignKey("Institution")]
        public int? InstitutionId { get; set; }

        public ICollection<PersonCompany> PersonCompany { get; set; }
        public Institution Institution { get; set; }
    }
}
