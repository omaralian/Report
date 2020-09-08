using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Report.Model;
using Report.Service;

namespace Report.Web.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        public IActionResult Index()
        {
            List<ReportModel> reportModel = _reportService.GetAll().ToList();
            return View(reportModel);
        }
    }
}
