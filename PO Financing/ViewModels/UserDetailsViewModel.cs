﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PO_Financing.Enums;
using PO_Financing.Models;

namespace PO_Financing.ViewModels
{
    public class UserDetailsViewModel
    {
        public string Id { get; set; }
        
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string UserRole { get; set; }

        public AccountStatus AccountStatus { get; set; }

    }
}
