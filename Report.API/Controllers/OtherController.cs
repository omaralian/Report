using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Report.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OtherController : ControllerBase
    {
        [HttpGet("ver")]
        public string Version()
        {
            return "Version 1.0.0";
        }

        [HttpGet("bat")]
        public ActionResult<IEnumerable<string>> Test()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
