namespace PO_Financing.ViewModels
{
    public class WalletViewModel
    {
        public string UserId { get; set; }

        public double TotalPurchaseOrdersAmount { get; set; }

        public double TotalQuotationAmount { get; set; }

        public double TotalInterestPaid { get; set; }

        public int TotalPurchaseOrders { get; set; }
    }
}
