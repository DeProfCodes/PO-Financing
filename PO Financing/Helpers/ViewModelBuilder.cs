using PO_Financing.ViewModels;
using PO_Financing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using PO_Financing.Data;
using PO_Financing.Helpers;

namespace PO_Financing.Helper
{
    public static class ViewModelBuilder
    {
        public static UserDetailsViewModel CreateUserViewModel(ApplicationUser user, string role)
        {
            var userVM = new UserDetailsViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                PhoneNumber = user.PhoneNumber,
                UserRole = role,
                AccountStatus = user.AccountStatus
            };
            return userVM;
        }

        public static PurchaseOrderApplication PurchaseOrderApplicationModel(PurchaseOrderApplicationViewModel poaVm)
        {
            var application = new PurchaseOrderApplication
            {
                UserId = poaVm.UserId,    
                BusinessEmail = poaVm.BusinessEmail,
                PhoneNumber = poaVm.PhoneNumber,
                BusinessName = poaVm.BusinessName,
                BusinessRegistrationNumber = poaVm.BusinessRegistrationNumber,
                Website = poaVm.Website,
                Address = poaVm.Address,
                PurchaseOrderDescription = poaVm.PurchaseOrderDescription,
                PurchaseOrderFunder = poaVm.PurchaseOrderFunder,
                PrimaryPersonPhoneNumber = poaVm.PrimaryPersonPhoneNumber,
                PurchaseOrderIssueDate = poaVm.PurchaseOrderIssueDate,
                PurchaseOrderDueDate = poaVm.PurchaseOrderDueDate,
                PurchaseOrderAmount = poaVm.PurchaseOrderAmount,
                PurchaseOrderNumber = poaVm.PurchaseOrderNumber,
                InvoiceAmount = poaVm.QuotationAmount,
                SupplierOfGoods = poaVm.SupplierOfGoods,
                Status = poaVm.Status,
            };

            return application;
        }

        public static WalletViewModel CreateUserWalletViewModel(PurchaseOrderApplicationViewModel poaVm)
        {
            var walletVm = new WalletViewModel
            {
                UserId = poaVm.UserId,
                TotalInterestPaid = Constants.Charges.Interests,
                TotalPurchaseOrders = 1,
                TotalPurchaseOrdersAmount = poaVm.PurchaseOrderAmount,
                TotalQuotationAmount = poaVm.QuotationAmount
            };
            return walletVm;
        }
    }
}
