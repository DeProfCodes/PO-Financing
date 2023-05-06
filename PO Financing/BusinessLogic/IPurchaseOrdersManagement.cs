using PO_Financing.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PO_Financing.BusinessLogic
{
    public interface IPurchaseOrdersManagement
    {
        public Task CreatePurchaseOrderApplication(PurchaseOrderApplication application);

        public Task<List<PurchaseOrderApplication>> GetAllPurcahseOrdersApplications();

        public Task<List<PurchaseOrderApplication>> GetUserPurcahseOrdersApplications(string userId);
    }
}
