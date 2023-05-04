using PO_Financing.Data;
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

        public async Task CreatePurchaseOrder()
        {
            
        }
    }
}
