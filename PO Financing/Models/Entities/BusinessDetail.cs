using System;

namespace PO_Financing.Models.Entities
{
    public class BusinessDetail : EntityBase
    {
        public string BusinessName { get; set; }
        public string RegistrationNumber { get; set; }
        public string Website { get; set; }
    }
}
