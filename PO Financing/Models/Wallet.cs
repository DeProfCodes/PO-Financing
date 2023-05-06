namespace PO_Financing.Models
{
    public class Wallet
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public double TotalPurchaseOrdersAmount { get; set; }

        public double TotalQuotationAmount { get; set; }    

        public double TotalInterestPaid { get; set; }   

        public int TotalPurchaseOrders {get; set; } 
    }
}
