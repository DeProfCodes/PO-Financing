using PO_Financing.Models;
using PO_Financing.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PO_Financing.BusinessLogic
{
    public interface IWalletManagement
    {
        public Task<List<Wallet>> GetAllWallets();

        public Task UpdateUserWallet(WalletViewModel userWallet);

        public Task<Wallet> GetUserWallet(string userId);

        public Task CreateUserWallet(Wallet userWallet);
    }
}
