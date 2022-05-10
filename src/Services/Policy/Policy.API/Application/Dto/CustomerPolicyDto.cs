using Policy.API.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Policy.API.Application.Dto
{
    public class CustomerPolicyDto
    {
        public int PolicyNumber { get; set; }
        public int CustomerId { get; set; }
        public DateTime IssuedOn { get; set; }
        public DateTime StartsOn { get; set; }
        public DateTime ExpiresOn { get; set; }
        public PolicyType PolicyType { get; set; }
        public PolicyStatus PolicyStatus { get; set; }
    }
}
