using System;

namespace PO_Financing.Models.Entities
{
    public class ApplicationDocument : EntityBase
    {
        public string BusinessRegistration { get; set; }
        public string DirectorsIdDocument { get; set; }
        public string PurchaseOrder { get; set; }
        public string Quotation { get; set; }
    }
}
