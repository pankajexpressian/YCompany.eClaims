using Policy.API.Application.Enums;
using System;

namespace Policy.API.Application.Dto
{
    public class ReadPolicyDto
    {
        public int PolicyNumber { get; set; }
        public int CustomerId { get; set; }
        public DateTimeOffset IssuedOn { get; set; }
        public DateTimeOffset StartsOn { get; set; }
        public DateTimeOffset ExpiresOn { get; set; }
        public PolicyType PolicyType { get; set; }
        public PolicyStatus PolicyStatus { get; set; }
        public bool SignedUpAlready { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; protected set; }
    }
}
