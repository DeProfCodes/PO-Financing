using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PO_Financing.BusinessLogic;
using PO_Financing.Data;
using PO_Financing.Enums;
using PO_Financing.Models;
using PO_Financing.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PO_Financing.Helper;

namespace PO_Financing.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IUserDataManagement _usersIO;
        private readonly IWalletManagement _walletManager;
        public AccountController(ApplicationDbContext dbContext,UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<AccountController> logger, IUserDataManagement usersIO, IWalletManagement walletManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _usersIO = usersIO;
            _walletManager = walletManager;
        }

        public async Task<IActionResult> Login()
        {
            await _signInManager.SignOutAsync();
            await HttpContext.SignOutAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var user = await _usersIO.GetUserByEmail(model.Email.Trim());

                    if (user.AccountStatus != AccountStatus.Active)
                    {
                        ModelState.AddModelError(string.Empty, "Account is not ACTIVE, contact management");
                        return View();
                    }

                    var userRole = await _usersIO.GetUserRoleByEmail(model.Email.Trim());
                    _logger.LogInformation("User logged in.");

                    //await HttpContext.SignInAsync();
                    if (userRole == UserRole.Client.GetDisplayName())
                    {
                        return RedirectToAction("Index", "Dashboard");
                    }
                    else if (userRole == UserRole.Admin.GetDisplayName())
                    {
                        return RedirectToAction("AdminIndex", "Dashboard");
                    }
                    ModelState.AddModelError(string.Empty, "Unknown User!");
                    return View();
                }
                if (result.RequiresTwoFactor)
                {
                    //return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View();
                }
            }

            // If we got this far, something failed, redisplay form
            return View();
        }

        public async Task<IActionResult> Register()
        {
            await _signInManager.SignOutAsync();
            await HttpContext.SignOutAsync();
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(registerViewModel.Password))
                {
                    if (!Validators.IsValidPassword(registerViewModel.Password))
                    {
                        ModelState.AddModelError(string.Empty, "Password must 8 or more characters, upper case, lowecase, number, special characters!");
                        return View(registerViewModel);
                    }
                }
                IDbContextTransaction transaction = _dbContext.Database.BeginTransaction();
                try
                {
                    var userId = await _usersIO.CreateUser(registerViewModel);
                    await _walletManager.CreateUserWallet(ViewModelBuilder.CreateNewUserWallet(userId));

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    _logger.LogError($"There was an error registering new account with email {registerViewModel.Email}");
                }
                //return View();
                var result = await _signInManager.PasswordSignInAsync(registerViewModel.Email, registerViewModel.Password, false, lockoutOnFailure: false);
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }

        public async Task<IActionResult> Settings()
        {
            try
            {
                var user = await _usersIO.GetUserByEmail(User.Identity.Name);
                var userVm = ViewModelBuilder.CreateUserViewModel(user, UserRole.Client.GetDisplayName());

                return View(userVm);
            }
            catch (Exception ex)
            {

            }
            return View(new UserDetailsViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Settings(UserDetailsViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _usersIO.GetUserByEmail(User.Identity.Name);
                
                userViewModel.Id = user.Id;
                userViewModel.Email = User.Identity.Name;
                
                if (!string.IsNullOrEmpty(userViewModel.Password))
                {
                    if (!Validators.IsValidPassword(userViewModel.Password))
                    {
                        ModelState.AddModelError(string.Empty, "Password must 8 or more characters, upper case, lowecase, number, special characters!");
                        return View(userViewModel);
                    }
                    userViewModel.Firstname = user.Firstname;
                    userViewModel.Lastname = user.Lastname;
                    userViewModel.PhoneNumber = user.PhoneNumber;
                }

                IDbContextTransaction transaction = _dbContext.Database.BeginTransaction();
                try
                {
                    await _usersIO.EditUser(userViewModel);

                    await transaction.CommitAsync();

                    return RedirectToAction("Index", "Dashboard");
                }
                catch (Exception e)
                {
                    await transaction.RollbackAsync();

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

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login", "Account");
        }
    }
}
