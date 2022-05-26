using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Notification.API.Models
{
    public class SMSNotification
    {
        [Key]
        public int Id { get; set; }
        public string From { get; set; }
        public string To{ get; set; }
        public string NotificationContent { get; set; }
    }
}
