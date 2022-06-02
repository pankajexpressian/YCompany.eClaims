using AutoMapper;
using Claim.Application.Features.AddClaim;

namespace Claim.API.Mappings
{
    public class ClaimMappings : Profile
    {
        public ClaimMappings()
        {
            CreateMap<AddClaimCommand, AddClaimRequest>().ReverseMap();
        }
    }
}
