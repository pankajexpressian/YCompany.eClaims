using System.ComponentModel.DataAnnotations;
using System;

namespace Customer.API.Domain.Entities
{
    public class CustomerDetail : TrackableEntity
    {
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTimeOffset DOB { get; set; }
        public CustomerStatus CustomerStatus { get; set; }
    }

    public enum CustomerStatus
    {
        Inactive, Active, Blocked
    }
}
