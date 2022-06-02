using AutoMapper;
using Claim.Application.Features.AddClaim;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Claim.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClaimsController : ControllerBase
    {
        private readonly IMediator _mediatr;
        private readonly IMapper _mapper;

        public ClaimsController(IMediator mediatr, IMapper mapper)
        {
            _mediatr = mediatr;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("This is claims service");
        }

        [HttpPost]
        public async Task<IActionResult> PostClaim(AddClaimRequest addClaimRequest)
        {
            var command = _mapper.Map<AddClaimCommand>(addClaimRequest);
            var res = await _mediatr.Send(command);
            return Ok(res);
        }
    }
}
