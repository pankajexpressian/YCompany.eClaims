using Policy.API.Application.Enums;
using System;

namespace Policy.API.Application.Dto
{
    public class CreatePolicyDto
    {
        public DateTimeOffset IssuedOn { get; set; }
        public DateTimeOffset StartsOn { get; set; }
        public DateTimeOffset ExpiresOn { get; set; }
        public PolicyType PolicyType { get; set; }
        public PolicyStatus PolicyStatus { get; set; }
    }
}
