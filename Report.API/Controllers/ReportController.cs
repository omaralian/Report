using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Report.Repository;

namespace Report.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private IInvitationRepository _invitationRepository;
        public ReportController(IInvitationRepository invitationRepository)
        {
            _invitationRepository = invitationRepository;
        }

        [HttpGet("invitation")]
        public async Task<IActionResult> Invitation()
        {
            var result = await _invitationRepository.ReportAsync();
            return Ok(result);
        }
    }
}
