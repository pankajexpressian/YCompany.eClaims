using AutoMapper;
using Claim.Application.Features.AddClaim;
using Claim.Application.Features.GetClaim;
using Claim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claim.Application.Mappings
{
    internal class ClaimMappings:Profile
    {
        public ClaimMappings()
        {
            CreateMap<ClaimDetailList,GetClaimResponseList>().ReverseMap();
            CreateMap<AddClaimRequest, AddClaimCommand>().ReverseMap();
            CreateMap<ClaimDetail,AddClaimCommand>().ReverseMap();
            CreateMap<ClaimDetail,AddClaimResponse>().ReverseMap();
            CreateMap<ClaimDetail,GetClaimResponse>().ReverseMap();
        }
    }
}
