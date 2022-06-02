using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reporting.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportingController : ControllerBase
    {
        

        public ReportingController()
        {
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("This is reporting controller");
        }
    }
}
