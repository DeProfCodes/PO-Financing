using System;

namespace PO_Financing.Models
{
    public class PurchaseOrderApplication
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        
        public string BusinessEmail { get; set; }

        public string PhoneNumber { get; set; }

        public string BusinessName { get; set; }

        public string BusinessRegistrationNumber { get; set; }

        public string Website { get; set; }

        public string Address { get; set; }

        public string PurchaseOrderDescription { get; set; }

        public string PurchaseOrderFunder { get; set; }

        public string PrimaryPersonPhoneNumber { get; set; }

        public DateTime PurchaseOrderIssueDate { get; set; }

        public DateTime PurchaseOrderDueDate { get; set; }

        public double PurchaseOrderAmount { get; set; }

        public double QuotationAmount { get; set; }

        public string PurchaseOrderNumber { get; set; }

        public string SupplierOfGoods { get; set; }

        public string Status { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
