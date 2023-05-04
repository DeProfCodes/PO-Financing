using PO_Financing.ViewModels;
using PO_Financing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using PO_Financing.Data;

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
    }
}
