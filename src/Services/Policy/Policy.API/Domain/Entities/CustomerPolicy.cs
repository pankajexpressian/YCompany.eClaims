using Policy.API.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Policy.API.Domain.Entities
{
    public class CustomerPolicy: TrackableEntity
    {
        [Key]
        public int PolicyNumber { get; set; }
        public int CustomerId { get; set; }
        public DateTimeOffset IssuedOn { get; set; }
        public DateTimeOffset StartsOn { get; set; }
        public DateTimeOffset ExpiresOn { get; set; }
        public PolicyType PolicyType { get; set; }
        public PolicyStatus PolicyStatus { get; set; }
    }
}
