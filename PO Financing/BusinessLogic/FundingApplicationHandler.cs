using Microsoft.AspNetCore.Identity;
using PO_Financing.BusinessLogic.Interfaces;
using PO_Financing.Data;
using PO_Financing.Data.Repositories;
using PO_Financing.Models.Entities;
using PO_Financing.ViewModels;
using System.Threading.Tasks;

namespace PO_Financing.BusinessLogic
{
    public class FundingApplicationHandler : IFundingApplicationHandler
    {
        private readonly IGenericRepository<PersonalDetail> _personalDetailsRepo;
        private readonly ApplicationDbContext _dbContext;

        public FundingApplicationHandler(IGenericRepository<PersonalDetail> personalDetailsRepo, ApplicationDbContext dbContext)
        {
            _personalDetailsRepo = personalDetailsRepo;
            _dbContext = dbContext;
        }
        public async Task<FundingApplicationViewModel> ApplyForFunding(FundingApplicationViewModel request)
        {
            //To make this a transaction, save changes at the very end
            //Save Personal details
            PersonalDetail personalDetails = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                IdNumber = request.IdNumber,
                BusinessEmail = request.BusinessEmail,
                PhoneNumber = request.PhoneNumber,
            };
            Address address = new()
            {
                Line1 = request.Line1,
                Line2 = request.Line2,
                City = request.City,
                Country = request.Country,
                Province = request.Province,
                PostalCode = request.PostalCode,
            };
            BusinessDetail businessDetail = new()
            {
                BusinessName = request.BusinessName,
                RegistrationNumber = request.RegistrationNumber,
                Website = request.Website,
            };

            PurchaseOrder application = new()
            {
                PurchaseOrderReason = request.PurchaseOrderReason,
                
            };
            _personalDetailsRepo.Insert(personalDetails);

            //Save the files on the machine
            _dbContext.Add(personalDetails);
            _dbContext.Add(address);
            _dbContext.Add(businessDetail);
            _dbContext.Add(application);

            await _dbContext.SaveChangesAsync();

            return new();
        }
    }
}
