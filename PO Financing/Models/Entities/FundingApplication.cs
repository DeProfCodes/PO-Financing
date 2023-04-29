using System;
using System.Collections.Generic;

namespace PO_Financing.Models.Entities
{
    public class FundingApplication : EntityBase
    {
        public long PersonalDetailId { get; set; }
        public long PurchaseOrderId { get; set; }
        public long BusinessDetailId { get; set; }
        public long ApplicationDocumentId { get; set; }
        public virtual ICollection<PersonalDetail> PersonalDetails { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual ICollection<BusinessDetail> BusinessDetails { get; set; }
        public virtual ICollection<ApplicationDocument> ApplicationDocuments { get; set; }
    }
}
