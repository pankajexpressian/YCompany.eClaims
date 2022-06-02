using AutoMapper;
using Claim.Application.Features.AddClaim;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claim.Application.Services
{
    public interface IClaimService
    {
        Task<AddClaimResponse> AddClaim(AddClaimRequest addClaimRequest);
    }

    internal class ClaimService : IClaimService
    {
        private readonly IMediator _mediatr;
        private readonly IMapper _mapper;
        public ClaimService(IMediator mediatr, IMapper mapper)
        {
            _mediatr=mediatr;
            _mapper=mapper;
        }
        public async Task<AddClaimResponse> AddClaim(AddClaimRequest addClaimRequest)
        {

            var command = _mapper.Map<AddClaimCommand>(addClaimRequest);
            var res = await _mediatr.Send(command);
            return res;
        }
    }
}
