using System;

namespace eClaims.Web.Models
{
    public class CustomerSignupDto
    {
        public int PolicyNumber { get; set; }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTimeOffset DOB { get; set; }
    }
}
