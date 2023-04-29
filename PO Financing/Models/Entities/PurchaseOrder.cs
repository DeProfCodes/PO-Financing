using System;
using System.Collections.Generic;

namespace PO_Financing.Models.Entities
{
    public class PurchaseOrder : EntityBase
    {
        //Purchase Order Details
        public long PurchaseOrderLegalEntityId { get; set; }
        public string PurchaseOrderReason { get; set; }
        public DateTime PurchaseOrderIssueDate { get; set; }
        public DateTime PurchaseOrderDueDate { get; set; }
        public decimal InvoiceAmount { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string SupplierOfGoods { get; set; }
        public virtual ICollection<PurchaseOrderLegalEntity> PurchaseOrderLegalEntities { get; set; }
    }
}
