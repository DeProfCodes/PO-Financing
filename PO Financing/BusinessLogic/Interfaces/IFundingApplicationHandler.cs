using PO_Financing.ViewModels;
using System.Threading.Tasks;

namespace PO_Financing.BusinessLogic.Interfaces
{
    public interface IFundingApplicationHandler
    {
        public Task<FundingApplicationViewModel> ApplyForFunding(FundingApplicationViewModel request);
    }
}
