﻿using System.ComponentModel.DataAnnotations;

namespace PO_Financing.Enums
{
    public enum AccountStatus
    {
        [Display(Name = "Active")]
        Active = 1,

        [Display(Name = "Suspended")]
        Suspended = 2,

        [Display(Name = "Paused")]
        Paused = 3,

        [Display(Name = "Deleted")]
        Deleted = 4
    }
}
