using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAggregator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceAggregatorController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Aggregator Service");
        }
    }
}
