using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using PO_Financing.BusinessLogic;
using PO_Financing.Data;
using PO_Financing.Enums;
using PO_Financing.Models;
using PO_Financing.ViewModels;
using PO_Financing.Helper;
using System.Collections.Generic;

namespace PO_Financing.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly IUserDataManagement _usersIO;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _dbContext;
        private readonly IPurchaseOrdersManagement _poManager;
        private readonly IWalletManagement _walletManager;

        public DashboardController(ILogger<DashboardController> logger, IUserDataManagement usersIO, ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IPurchaseOrdersManagement poManager, IWalletManagement walletManager)
        {
            _logger = logger;
            _usersIO = usersIO;
            _dbContext = dbContext;
            _signInManager = signInManager;
            _userManager = userManager;
            _poManager = poManager;
            _walletManager = walletManager;
        }

        private async Task<bool> IsLoggedInUserIsAdmin()
        {
            var userRole = await _usersIO.GetUserRoleByEmail(User.Identity.Name);

            return (userRole == UserRole.Admin.GetDisplayName());
        }

        [Authorize]
        public async Task<IActionResult> Dashboard()
        {
            var userRole = await _usersIO.GetUserRoleByEmail(User.Identity.Name);

            if (userRole == UserRole.Admin.GetDisplayName())
            {
                return RedirectToAction("AdminIndex", "Dashboard");
            }
            else if (userRole == UserRole.Client.GetDisplayName())
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return RedirectToAction("Login", "Account");
        }

        #region ADMIN PAGES
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminIndex()
        {
            var user = await _usersIO.GetUserByEmail(User.Identity.Name);
            var userRole = await _usersIO.GetUserRole(user.Id);

            if (userRole == UserRole.Admin.GetDisplayName())
            {
                return View();
            }
            else
            {
                return Unauthorized();
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> OpenUsersManagement()
        {
            //return Unauthorized();
            bool isAdminUser = await IsLoggedInUserIsAdmin();
            if (!isAdminUser)
                return Unauthorized();

            return RedirectToAction("UsersManagement", "UserDetails");
        }

        #endregion

        #region CLIENT PAGES

        public async Task<IActionResult> Index()
        {
            try
            {
                var user = await _usersIO.GetUserByEmail(User.Identity.Name);
                var userRole = await _usersIO.GetUserRole(user.Id);
                var userWallet = await _walletManager.GetUserWallet(user.Id);

                if (userRole == UserRole.Client.GetDisplayName())
                {
                    var dashboardVm = ViewModelBuilder.CreateDashboardViewModel(userWallet);

                    return View(dashboardVm);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> PurchaseOrders()
        {
            try
            {
                var user = await _usersIO.GetUserByEmail(User.Identity.Name);
                var userPorders = await _poManager.GetUserPurcahseOrdersApplications(user.Id);

                var userPOsApplicationsVm = ViewModelBuilder.CreateUserPurchaseOrderApplicationsViewModel(userPorders);

                var POs = new PurchaseOrdersViewModel
                {
                    PurchaseOrderApplication = userPOsApplicationsVm
                };
                return View(POs);
            }
            catch (Exception e)
            {
                return View(new PurchaseOrdersViewModel());
            }
        }

        #endregion
    }
}
