using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Report.Service;
using Report.Web.Models;

namespace Report.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IInvitationService _invitationService;

        public HomeController(ILogger<HomeController> logger, IInvitationService invitationService)
        {
            _logger = logger;
            _invitationService = invitationService;
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

        public async Task<IActionResult> CreateReport(string? type)
        {
            if (type.IsNullOrEmpty())
                type = "html";

            await _invitationService.InvitationReport(type);

            return RedirectToAction("Index", "Report");
        }
    }
}
