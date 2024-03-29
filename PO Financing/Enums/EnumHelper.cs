﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using System.Reflection;

namespace PO_Financing.Enums
{
    public static class EnumHelpers
    {
        /// <summary>
        /// Display the name set in annotation DisplayName on top of enum value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDisplayName(this Enum value)
        {
            return value.GetType()?
           .GetMember(value.ToString())?.First()?
           .GetCustomAttribute<DisplayAttribute>()?
           .Name;
        }
    }
}
