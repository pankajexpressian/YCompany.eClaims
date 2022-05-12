using Customer.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.API.Inrastructure.Data
{
    public class CustomerDataSeeder
    {
        public async static Task MigrateDatabases(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            if (host != null)
            {
                var context = services.GetRequiredService<CustomerContext>();
                var logger = services.GetRequiredService<ILogger<CustomerDataSeeder>>();

                try
                {
                    await context.Database.MigrateAsync();
                    logger.LogInformation("Customer database has been created successfully and migrations have also been run.");
                }
                catch (Exception ex)
                {
                    logger.LogError("Error while migrating the customer databases.", ex);
                }

                await SeedCustomerData(context, logger);

            }
        }

        private async static Task SeedCustomerData(CustomerContext context, ILogger<CustomerDataSeeder> logger)
        {
            try
            {
                if (!context.Customers.Any())
                {
                    await context.Customers.AddRangeAsync(GetCustomerData());
                    await context.SaveChangesAsync();
                    logger.LogInformation("Data has been seeded for Customers.");
                }

            }
            catch (Exception ex)
            {
                logger.LogError("Error while seeding the Customer data.", ex);
            }
        }

        private static IEnumerable<CustomerDetail> GetCustomerData()
        {
            List<CustomerDetail> customers = new List<CustomerDetail>();

            customers.Add(
            new CustomerDetail()
            {
                CustomerId = 1,
                FirstName = "Pankaj",
                LastName = "Jangid",
                Email = "pankajexpressian92@gmail.com",
                DOB = Convert.ToDateTime("1990-01-20"),
                CustomerStatus=CustomerStatus.Active,
            });



            return customers;
        }
    }
}
