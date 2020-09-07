using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Mvc;
using Report.Repository;
using Report.Service;

namespace Report.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : Controller
    {
        private IInvitationService _invitationService;
        public ReportController(IInvitationService invitationService)
        {
            _invitationService = invitationService;
        }

        [HttpGet("invitation")]
        public IActionResult Invitation(string? type)
        {
            if (type.IsNullOrEmpty())
                type = "html";

            string filename = string.Format(@"{0}", Guid.NewGuid().ToString());

            var tasks = Task.Run(() => _invitationService.InvitationReportAsync(filename, type));

            string link = "ReportStaticFiles/" + filename + "." + type;
            return Ok(link);
        }
    }
}
