using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PO_Financing.Data;
using PO_Financing.Enums;
using PO_Financing.Models;
using PO_Financing.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PO_Financing.BusinessLogic.Interfaces;

namespace PO_Financing.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IUserDataManagement _usersIO;
        
        public AccountController(ApplicationDbContext dbContext,UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<AccountController> logger, IUserDataManagement usersIO)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _usersIO = usersIO;
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
                IDbContextTransaction transaction = _dbContext.Database.BeginTransaction();
                try
                {
                    var userId = await _usersIO.CreateUser(registerViewModel);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _logger.LogError($"There was an error registering new account with email {registerViewModel.Email}");
                }
                return View();
                //return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login", "Account");
        }
    }
}
