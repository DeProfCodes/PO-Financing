using PO_Financing.Enums;

namespace PO_Financing.Helpers
{
    public static class HtmlViewHelper
    {
        public static string GetStatusBgColor(string status)
        {
            if (status == PurchaseOrderStatus.Pending.GetDisplayName() || status == PurchaseOrderStatus.PendingDocuments.GetDisplayName())
                return "bg-wanring";

            if (status == PurchaseOrderStatus.Rejected.GetDisplayName())
                return "bg-danger";

            if (status == PurchaseOrderStatus.InProgress.GetDisplayName())
                return "bg-primary";

            if (status == PurchaseOrderStatus.Accepted.GetDisplayName())
                return "bg-info";

            if (status == PurchaseOrderStatus.Complete.GetDisplayName())
                return "bg-success";

            return "bg-secondary";
        }
    }
}
