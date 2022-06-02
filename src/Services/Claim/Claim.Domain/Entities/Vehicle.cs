using System;

namespace Claim.Domain.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTimeOffset ResigrationDate { get; set; }
        public string Manufacturarer { get; set; }
        public string Description { get; set; }
    }
}
