using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System.Globalization;
using System.Threading.Tasks;
using System;
using PO_Financing.Data;
using PO_Financing.Enums;
using PO_Financing.BusinessLogic;
using PO_Financing.ViewModels;
using PO_Financing.Helper;
using System.Linq;
using PO_Financing.Models;
using Microsoft.AspNetCore.Authorization;

namespace PO_Financing.Controllers
{
    [Authorize]
    public class UserDetailsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<UserDetailsController> _logger;
        private readonly IUserDataManagement _usersIO;
        private readonly ApplicationDbContext _dbContext;

        public UserDetailsController(UserManager<ApplicationUser> userManager, ILogger<UserDetailsController> logger, IUserDataManagement usersIO, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _logger = logger;
            _usersIO = usersIO;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> UsersManagement()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View(new UserDetailsViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDetailsViewModel userViewModel)
        {
            IDbContextTransaction transaction = _dbContext.Database.BeginTransaction();
            try
            {
                var userId = await _usersIO.CreateUser(userViewModel);

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
            }
            return RedirectToAction("UsersManagement", "UserDetails");
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string userId)
        {
            var user = await _usersIO.GetUserByUserId(userId);
            var userRole = await _usersIO.GetUserRole(userId);

            userRole = userRole == UserRole.Admin.GetDisplayName() ? "" : userRole;

            var userDtailsVm = ViewModelBuilder.CreateUserViewModel(user, userRole);
            
            return View(userDtailsVm);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(UserDetailsViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(userViewModel.Password))
                {
                    if (!Validators.IsValidPassword(userViewModel.Password))
                    {                        
                        ModelState.AddModelError(string.Empty, "Password must 8 or more characters, upper case, lowecase, number, special char!");
                        return View();
                    }
                }

                IDbContextTransaction transaction = _dbContext.Database.BeginTransaction();
                try
                {
                    await _usersIO.EditUser(userViewModel);

                    transaction.Commit();

                    return RedirectToAction("UsersManagement", "UserDetails");
                }
                catch (Exception e)
                {
                    transaction.Rollback();

                    ModelState.AddModelError(string.Empty, e.Message);
                    return View(userViewModel);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error.");
                return View(userViewModel);
            }
        }

        public async Task<IActionResult> SuspendUser(string userId)
        {
            await _usersIO.UpdateUserAccountStatus(userId, AccountStatus.Suspended);

            return RedirectToAction("UsersManagement", "UserDetails");
        }

        public async Task<IActionResult> DeleteUser(string userId)
        {
            await _usersIO.UpdateUserAccountStatus(userId, AccountStatus.Deleted);

            return RedirectToAction("UsersManagement", "UserDetails");
        }

        public async Task<IActionResult> SuperDeleteUser(string userId)
        {
            IDbContextTransaction transaction = _dbContext.Database.BeginTransaction();
            try
            {
                await _usersIO.SuperDeleteUser(userId);

                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
            }
            return RedirectToAction("UsersManagement", "UserDetails");
        }
    }
}
