using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apointment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApointmentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("This is apointments service");
        }
    }
}
