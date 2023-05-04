using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PO_Financing.Models;
using PO_Financing.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PO_Financing.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public ApplicationController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Apply()
        {
            return View();
        }

        //[HttpPost]
        public IActionResult Apply2(PurchaseOrderApplicationViewModel purchaseOrderApplication)
        {
            return View();
        }
    }
}
