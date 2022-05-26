using Microsoft.EntityFrameworkCore;
using Notification.API.Models;

namespace Notification.API.Data
{
    public class NotificationContext : DbContext
    {
        public NotificationContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<EmailNotification> EmailNotifications { get; set; }
        public DbSet<SMSNotification> SMSNotifications { get; set; }
        public DbSet<WhatsappNotification> WhatsappNotifications { get; set; }
    }
}
