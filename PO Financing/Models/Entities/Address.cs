using System;

namespace PO_Financing.Models.Entities
{
    public class Address : EntityBase
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }
    }
}
