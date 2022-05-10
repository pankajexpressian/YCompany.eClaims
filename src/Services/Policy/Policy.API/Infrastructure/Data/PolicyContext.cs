using Microsoft.EntityFrameworkCore;
using Policy.API.Domain.Entities;

namespace Policy.API.Infrastructure.Data
{
    public class PolicyContext : DbContext
    {
        public PolicyContext(DbContextOptions<PolicyContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<CustomerPolicy> Policies { get; set; }
    }
}
