using AutoMapper;
using Claim.Application.Features.AddClaim;
using Claim.Application.Features.GetClaim;
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
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediatr.Send(new GetClaimQuery()));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetClaim(int id)
        {
            return Ok(await _mediatr.Send(new GetClaimQuery() { Id = id }));
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
