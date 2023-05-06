using System;
using System.ComponentModel.DataAnnotations;

namespace PO_Financing.ViewModels
{
    public class PurchaseOrderApplicationViewModel
    {
        public string UserId { get; set; }
        
        public string IdNumber {get; set;}
        
        public string BusinessEmail { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public string BusinessName { get; set; }

        [Required]
        public string BusinessRegistrationNumber { get; set; }

        public string Website { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PurchaseOrderDescription { get; set; }

        [Required]
        public string PurchaseOrderFunder { get; set; }

        [Required]
        public string PrimaryPersonPhoneNumber { get; set; }

        [Required]
        public DateTime PurchaseOrderIssueDate { get; set; }

        [Required]
        public DateTime PurchaseOrderDueDate { get; set; }

        [Required]
        public double PurchaseOrderAmount { get; set; }

        public string PurchaseOrderNumber { get; set; }

        [Required]
        public double QuotationAmount { get; set; }

        [Required]
        public string SupplierOfGoods { get; set; }

        public string Status { get; set; }
    }
}
