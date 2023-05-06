using Microsoft.EntityFrameworkCore;
using PO_Financing.Data;
using PO_Financing.Models;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<PurchaseOrderApplication>> GetAllPurcahseOrdersApplications()
        {
            var purchaseOrdersAppication = await _dbContext.PurchaseOrderApplications.ToListAsync();

            return purchaseOrdersAppication;
        }
        
        public async Task<List<PurchaseOrderApplication>> GetUserPurcahseOrdersApplications(string userId)
        {
            var userPurchaseOrders = (await GetAllPurcahseOrdersApplications()).Where(x=>x.UserId == userId).ToList();

            return userPurchaseOrders;
        }
    }
}
