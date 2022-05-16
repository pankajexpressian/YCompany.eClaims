using Policy.API.Domain.Entities;
using Policy.API.Application.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Policy.API.Application.Dto
{
    //Extend the Dto class from Trackable Entity if you need to get Audit details returned in API response
    //public class CustomerPolicyDto : TrackableEntity 
    public class OldCustomerPolicyDto
    {
        public int PolicyNumber { get; set; }
        public int CustomerId { get; set; }
        public DateTimeOffset IssuedOn { get; set; }
        public DateTimeOffset StartsOn { get; set; }
        public DateTimeOffset ExpiresOn { get; set; }
        public PolicyType PolicyType { get; set; }
        public PolicyStatus PolicyStatus { get; set; }
        public bool SignedUpAlready { get; set; } = false;
    }
}
