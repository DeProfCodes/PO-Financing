using PO_Financing.Data;
using PO_Financing.Models;
using System.Threading.Tasks;

namespace PO_Financing.BusinessLogic
{
    public class PurchaseOrdersManagement : IPurchaseOrdersManagement 
    {
        private readonly ApplicationDbContext _dbContext;
        
        public PurchaseOrdersManagement(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreatePurchaseOrderApplication(PurchaseOrderApplication application)
        {
            _dbContext.Add(application);
            await _dbContext.SaveChangesAsync();
        }
    }
}
