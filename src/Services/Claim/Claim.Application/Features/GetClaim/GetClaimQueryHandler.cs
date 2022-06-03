using AutoMapper;
using Claim.Application.Exceptions;
using Claim.Infrastructure.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Claim.Application.Features.GetClaim
{
    public class GetClaimQueryHandler : IRequestHandler<GetClaimQuery, IEnumerable<GetClaimResponse>>
    {
        private readonly IClaimRepository _claimRepository;
        private readonly IMapper _mapper;

        public GetClaimQueryHandler(IClaimRepository claimRepository, IMapper mapper)
        {
            _claimRepository = claimRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetClaimResponse>> Handle(GetClaimQuery request, CancellationToken cancellationToken)
        {
            var claimList = new List<GetClaimResponse>();
            if (request.ReturnAllClaims)
            {
                var claims = await _claimRepository.GetClaims();
                if (claims.Any())
                {
                    claimList.AddRange(_mapper.Map<List<GetClaimResponse>>(claims));
                }
            }

            if (!request.ReturnAllClaims && request.Id > 0)
            {
                var claim = await _claimRepository.GetClaim(request.Id);
                if (claim==null)
                {
                    throw new ClaimNotFoundException($"Claim with id {request.Id} could not be found.");
                }
                claimList.Add(_mapper.Map<GetClaimResponse>(claim));
            }
            return claimList;
        }
    }
}
