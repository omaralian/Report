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
        public async Task<IActionResult> Invitation(string type)
        {
            if (type.IsNullOrEmpty())
                type = "html";

            string filename = await _invitationService.InvitationReport(type);

            string link = "ReportStaticFiles/" + filename + "." + type;
            return Ok(link);
        }
    }
}
