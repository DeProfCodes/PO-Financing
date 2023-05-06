using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using PO_Financing.BusinessLogic;
using PO_Financing.Data;
using PO_Financing.Enums;
using PO_Financing.Helper;
using PO_Financing.Models;
using PO_Financing.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PO_Financing.Controllers
{
    
    public class ApplicationController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserDataManagement _users;
        private readonly ApplicationDbContext _dbContext;
        private readonly IPurchaseOrdersManagement _poManager;
        private readonly IWalletManagement _walletManager;

        public ApplicationController(ILogger<HomeController> logger, IUserDataManagement users, ApplicationDbContext dbContext, IPurchaseOrdersManagement poManager, IWalletManagement walletManager)
        {
            _logger = logger;
            _users = users;
            _dbContext = dbContext;
            _poManager = poManager;
            _walletManager = walletManager;
        }

        public IActionResult Apply()
        {
            if (User.Identity.Name == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        public async Task<IActionResult> CreateApplication(PurchaseOrderApplicationViewModel purchaseOrderApplication)
        {
            IDbContextTransaction transaction = _dbContext.Database.BeginTransaction();
            try
            {
                var userId = (await _users.GetUserByEmail(User.Identity.Name)).Id;
                purchaseOrderApplication.Status = PurchaseOrderStatus.Pending.GetDisplayName();
                purchaseOrderApplication.UserId = userId;

                var application = ViewModelBuilder.PurchaseOrderApplicationModel(purchaseOrderApplication);
                var userWalletVm = ViewModelBuilder.CreateUserWalletViewModel(purchaseOrderApplication);

                await _poManager.CreatePurchaseOrderApplication(application);

                await _walletManager.UpdateUserWallet(userWalletVm);

                await transaction.CommitAsync();

                return Ok();
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();

                return BadRequest();
            }
        }
    }
}
