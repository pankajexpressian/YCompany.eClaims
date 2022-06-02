using Claim.Domain.Entities;
using Claim.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claim.Application.Features.AddClaim
{
    public class AddClaimCommand:IRequest<AddClaimResponse>
    {
        public int PolicyId { get; set; }
        public int CustomerId { get; set; }
        public Vehicle VehicleDetails { get; set; }
        public DateTimeOffset SubmittedOn { get; set; }
        public ClaimStatus ClaimStatus { get; set; }
        public ClaimStage ClaimStage { get; set; }
    }
}
