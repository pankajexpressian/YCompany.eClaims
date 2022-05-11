using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Policy.API.Domain.Entities;
using Policy.API.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Policy.API.Infrastructure.Data
{
    public class PolicyDataSeeder
    {
        public async static Task MigrateDatabases(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            if (host != null)
            {
                var context = services.GetRequiredService<PolicyContext>();
                var logger = services.GetRequiredService<ILogger<PolicyDataSeeder>>();

                try
                {
                    await context.Database.MigrateAsync();
                    logger.LogInformation("Policy database has been created successfully and migrations have also been run.");
                }
                catch (Exception ex)
                {
                    logger.LogError("Error while migrating the databases.", ex);
                }

                await SeedPolicyData(context, logger);

            }
        }

        private async static Task SeedPolicyData(PolicyContext context, ILogger<PolicyDataSeeder> logger)
        {
            try
            {
                if (!context.Policies.Any())
                {
                    await context.Policies.AddRangeAsync(GetPolicyData());
                    await context.SaveChangesAsync();
                    logger.LogInformation("Data has been seeded for policies.");
                }

            }
            catch (Exception ex)
            {
                logger.LogError("Error while seeding the policy data.", ex);
            }
        }

        private static IEnumerable<CustomerPolicy> GetPolicyData()
        {
            List<CustomerPolicy> policies = new List<CustomerPolicy>();

            policies.Add(
            new CustomerPolicy()
            {
                CustomerId = 1,
                StartsOn = DateTime.Today.AddDays(5),
                ExpiresOn = DateTime.Today.AddDays(365),
                IssuedOn = DateTime.Today,
                PolicyStatus = PolicyStatus.Active,
                PolicyType = PolicyType.Auto
            });


            policies.Add(
            new CustomerPolicy()
            {
                CustomerId = 2,
                StartsOn = DateTime.Today.AddDays(15),
                ExpiresOn = DateTime.Today.AddDays(365),
                IssuedOn = DateTime.Today,
                PolicyStatus = PolicyStatus.Active,
                PolicyType = PolicyType.Auto
            });

            policies.Add(
            new CustomerPolicy()
            {
                CustomerId = 3,
                StartsOn = DateTime.Today.AddDays(15),
                ExpiresOn = DateTime.Today.AddDays(365),
                IssuedOn = DateTime.Today,
                PolicyStatus = PolicyStatus.Active,
                PolicyType = PolicyType.Auto
            });

            policies.Add(
            new CustomerPolicy()
            {
                CustomerId = 4,
                StartsOn = DateTime.Today.AddDays(15),
                ExpiresOn = DateTime.Today.AddDays(365),
                IssuedOn = DateTime.Today,
                PolicyStatus = PolicyStatus.Active,
                PolicyType = PolicyType.Auto
            });

            return policies;
        }
    }
}
