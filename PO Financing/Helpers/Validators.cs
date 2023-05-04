using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PO_Financing.Helper
{
    public class Validators
    {
        public static bool IsValidPassword(string password)
        {
            bool length = password.Length > 7;  
            bool containsLowerLetter = Regex.Matches(password, @"[a-z]").Count > 0;
            bool containsUpperLetter = Regex.Matches(password, @"[A-Z]").Count > 0;
            bool containsNumber = password.Any(x=>char.IsNumber(x));
            bool containsSpecialChar = password.Any(x => !char.IsLetterOrDigit(x));

            return length && containsLowerLetter && containsUpperLetter && containsNumber && containsSpecialChar;
        }
    }
}
