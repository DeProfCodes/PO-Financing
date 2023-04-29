using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PO_Financing.BusinessLogic.Interfaces;
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
        private readonly IFundingApplicationHandler _fundingApplicationHandler;

        public ApplicationController(ILogger<HomeController> logger, IFundingApplicationHandler fundingApplicationHandler)
        {
            _logger = logger;
            _fundingApplicationHandler = fundingApplicationHandler;
        }

        [Authorize]
        public async Task<IActionResult> ApplyAsync(FundingApplicationViewModel request)
        {
            var response = await _fundingApplicationHandler.ApplyForFunding(request);
            return View();
        }
    }
}
