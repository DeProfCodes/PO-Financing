using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PO_Financing.Enums
{
    public enum UserRole
    {
        [Display(Name = "Admin")]
        Admin = 1,

        [Display(Name = "Client")]
        Client = 2
    }
}
