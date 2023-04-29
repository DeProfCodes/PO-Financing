using System;
using System.Collections.Generic;

namespace PO_Financing.Models.Entities
{
    public class PersonalDetail : EntityBase
    {
        public long AddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        public string BusinessEmail { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
