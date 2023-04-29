using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PO_Financing.Models;
using PO_Financing.Services;
using PO_Financing.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PO_Financing.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICommunicationService _communication;

        public HomeController(ILogger<HomeController> logger, ICommunicationService communication)
        {
            _logger = logger;
            _communication = communication;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> SendEmailForm(SendEmailViewModel sendMailRequest)
        {
            var response = await _communication.SendEmailAsync(
                sendMailRequest.RecepientEmail,
                sendMailRequest.SenderEmail,
                sendMailRequest.SenderName,
                sendMailRequest.RecepientName,
                sendMailRequest.Subject,
                sendMailRequest.Body
                );
            return PartialView();
            //return $"Hello user with mail{sendMailRequest.SenderEmail}";
        }
    }
}
