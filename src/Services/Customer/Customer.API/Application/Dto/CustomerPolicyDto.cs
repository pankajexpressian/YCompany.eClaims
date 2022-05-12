
using System;

namespace Customer.API.Application.Dto
{
    //Extend the Dto class from Trackable Entity if you need to get Audit details returned in API response
    //public class CustomerDetailsDto : TrackableEntity 
    public class CustomerDetailDto
    {
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
