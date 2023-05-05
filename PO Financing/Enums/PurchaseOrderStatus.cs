using System.ComponentModel.DataAnnotations;

namespace PO_Financing.Enums
{
    public enum PurchaseOrderStatus
    {
        [Display(Name="Pending")]
        Pending,

        [Display(Name = "In Progress")]
        InProgress,

        [Display(Name = "Rejected")]
        Rejected,

        [Display(Name = "Accepted")]
        Accepted,

        [Display(Name = "Pending Documents")]
        PendingDocuments,

        [Display(Name = "Complete")]
        Complete,
    }
}
