using Claim.Infrastructure.Data;
using Claim.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Claim.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseName = configuration["ConnectionStrings:InMemoryClaimDb"];
            services.AddDbContext<ClaimDbContext>(options =>
            {
                options.UseInMemoryDatabase(databaseName);
            });

            services.AddScoped<IClaimRepository, ClaimRepository>();

            return services;
        }
    }
}
