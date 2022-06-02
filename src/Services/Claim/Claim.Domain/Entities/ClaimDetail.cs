using Claim.Domain.Enums;
using System;

namespace Claim.Domain.Entities
{
    public class ClaimDetail : TrackableEntity
    {
        public int Id { get; set; }
        public int PolicyId { get; set; }
        public int CustomerId { get; set; }
        public Vehicle VehicleDetails { get; set; }
        public DateTimeOffset SubmittedOn { get; set; }
        public ClaimStatus ClaimStatus { get; set; }
        public ClaimStage ClaimStage { get; set; }
    }
}
