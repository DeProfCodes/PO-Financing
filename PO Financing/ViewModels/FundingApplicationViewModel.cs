using System;
using System.ComponentModel.DataAnnotations;

namespace PO_Financing.ViewModels
{
    public class FundingApplicationViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string IdNumber { get; set; }
        [Required]
        public string BusinessEmail { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        //Address Information
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }

        //Business Details
        public string BusinessName { get; set; }
        public string RegistrationNumber { get; set; }
        public string Website { get; set; }

        //Purchase Order
        public string PurchaseOrderReason { get; set; }
        public long LegalEntityId { get; set; }
        public DateTime PurchaseOrderIssueDate { get; set; }
        public DateTime PurchaseOrderDueDate { get; set; }
        public decimal InvoiceAmount { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string SupplierOfGoods { get; set; }
        public string LegalEntity { get; set; }

        //Required Documents
        public byte[] BusinessRegistration { get; set; }
        public byte[] DirectorsIdDocument { get; set; }
        public byte[] PurchaseOrder { get; set; }
        public byte[] Quotation { get; set; }

    }
}
