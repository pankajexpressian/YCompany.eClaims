using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Notification.API.Models
{
    public class EmailNotification
    {
        [Key]
        public int Id { get; set; }
        public string FromEmailAddress { get; set; }
        public string FromName { get; set; }
        public string ToEmailAddress { get; set; }

        public string CCEmailAddress { get; set; }

        public string BCCEmailAddress { get; set; }

        public bool IsHTML { get; set; }
        public string EmailBody { get; set; }
    }
}
