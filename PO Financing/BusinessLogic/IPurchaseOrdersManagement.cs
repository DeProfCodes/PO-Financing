using PO_Financing.Models;
using System.Threading.Tasks;

namespace PO_Financing.BusinessLogic
{
    public interface IPurchaseOrdersManagement
    {
        public Task CreatePurchaseOrderApplication(PurchaseOrderApplication application); 
    }
}
