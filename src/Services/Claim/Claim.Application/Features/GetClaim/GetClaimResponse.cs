using Claim.Domain.Entities;
using Claim.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Claim.Application.Features.GetClaim
{
    public class GetClaimResponse
    {
        public int Id { get; set; }
        public int PolicyId { get; set; }
        public int CustomerId { get; set; }
        public Vehicle VehicleDetails { get; set; }
        public DateTimeOffset SubmittedOn { get; set; }
        public ClaimStatus ClaimStatus { get; set; }
        public ClaimStage ClaimStage { get; set; }
    }

    public class GetClaimResponseList
    {
        public IEnumerable<GetClaimResponse> GetClaimResponseLst { get; set; }
    }

    public class ClaimDetailList
    {
        public IEnumerable<ClaimDetailList> ClaimDetailLst { get; set; }
    }
}
