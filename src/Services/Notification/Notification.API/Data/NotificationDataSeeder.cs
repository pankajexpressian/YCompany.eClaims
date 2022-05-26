using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Notification.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.API.Data
{
    public class NotificationDataSeeder
    {
        public async static Task MigrateDatabases(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            if (host != null)
            {
                var context = services.GetRequiredService<NotificationContext>();
                var logger = services.GetRequiredService<ILogger<NotificationDataSeeder>>();

                try
                {
                    await context.Database.MigrateAsync();
                    logger.LogInformation("Notification database has been created successfully and migrations have also been run.");
                }
                catch (Exception ex)
                {
                    logger.LogError("Error while migrating the Notification databases.", ex);
                }

                await SeedNotificationData(context, logger);

            }
        }

        private async static Task SeedNotificationData(NotificationContext context, ILogger<NotificationDataSeeder> logger)
        {
            try
            {
                if (!context.EmailNotifications.Any())
                {
                    await context.EmailNotifications.AddRangeAsync(GetEmailNotificationData());
                    await context.SaveChangesAsync();
                    logger.LogInformation("Data has been seeded for Notification.");
                }

                if (!context.SMSNotifications.Any())
                {
                    await context.SMSNotifications.AddRangeAsync(GetSMSNotificationData());
                    await context.SaveChangesAsync();
                    
                }

                logger.LogInformation("Data has been seeded for Notification.");

            }
            catch (Exception ex)
            {
                logger.LogError("Error while seeding the Notification data.", ex);
            }
        }

        private static List<EmailNotification> GetEmailNotificationData()
        {
            return new List<EmailNotification>() {
            new EmailNotification(){
            FromEmailAddress="abcd@zyz.com",
            ToEmailAddress="qwerty@abc.com",
            EmailBody="This is sample email."
            }

            };
        }

        private static List<SMSNotification> GetSMSNotificationData()
        {
            return new List<SMSNotification>() {
            new SMSNotification(){
            From="12345",
            To="56789",
            NotificationContent="This is sample sms"
            }

            };
        }
    }
}
