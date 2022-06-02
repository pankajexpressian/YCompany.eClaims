using AutoMapper;
using Claim.Domain.Entities;
using Claim.Infrastructure.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Claim.Application.Features.AddClaim
{
    public class AddClaimCommandHandler : IRequestHandler<AddClaimCommand, AddClaimResponse>
    {
        private readonly IClaimRepository _claimRepository;
        private readonly IMapper _mapper;

        public AddClaimCommandHandler(IClaimRepository claimRepository, IMapper mapper)
        {
            _claimRepository = claimRepository;
            _mapper = mapper;
        }
        public async Task<AddClaimResponse> Handle(AddClaimCommand request, CancellationToken cancellationToken)
        {
            var claimToAdd = _mapper.Map<ClaimDetail>(request);
            var res = await _claimRepository.AddClaim(claimToAdd);

            if (res == null || res.Id <= 0)
            {
                //Throw error here
                throw new System.NotImplementedException();
            }

            var response = _mapper.Map<AddClaimResponse>(res);
            return response;
        }
    }
}
