using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserIdentity.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserIdentityController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("This is user identity service");
        }
    }
}
