using Microsoft.EntityFrameworkCore;
using PO_Financing.Data;
using PO_Financing.Models;
using PO_Financing.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO_Financing.BusinessLogic
{
    public class WalletManagement : IWalletManagement
    {
        private readonly ApplicationDbContext _dbContext;

        public WalletManagement(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Wallet>> GetAllWallets()
        {
            var wallets = await _dbContext.Wallets.ToListAsync();

            return wallets;
        }

        public async Task<Wallet> GetUserWallet(string userId)
        {
            var userWallet = (await GetAllWallets()).FirstOrDefault(x => x.UserId == userId);

            return userWallet;
        }

        public async Task CreateUserWallet(Wallet userWallet)
        {
            var existing = (await GetAllWallets()).FirstOrDefault(x => x.UserId == userWallet.UserId);

            if (existing == null)
            {
                _dbContext.Add(userWallet);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateUserWallet(WalletViewModel userWallet)
        {
            var existing = (await GetAllWallets()).FirstOrDefault(x => x.UserId == userWallet.UserId);

            if (existing != null)
            {
                existing.TotalPurchaseOrders += userWallet.TotalPurchaseOrders;
                existing.TotalPurchaseOrdersAmount += userWallet.TotalPurchaseOrdersAmount;
                existing.TotalInterestPaid += userWallet.TotalInterestPaid;
                existing.TotalQuotationAmount += userWallet.TotalQuotationAmount;

                _dbContext.Add(existing);
            }
            else
            {
                var newWallet = new Wallet
                {
                    UserId = userWallet.UserId,
                    TotalInterestPaid = userWallet.TotalInterestPaid,
                    TotalPurchaseOrders = userWallet.TotalPurchaseOrders,
                    TotalPurchaseOrdersAmount = userWallet.TotalPurchaseOrdersAmount,
                    TotalQuotationAmount = userWallet.TotalQuotationAmount
                };
                _dbContext.Add(newWallet);
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}
