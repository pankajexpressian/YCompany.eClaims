using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Notification.API.Dto
{
    public class SMSNotificationDto
    {
        public string From { get; set; }
        public string To{ get; set; }
        public string NotificationContent { get; set; }
    }
}
