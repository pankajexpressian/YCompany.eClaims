using AutoMapper;
using Notification.API.Dto;
using Notification.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace Notification.API.Mapper
{
    public class NotificationMappings : Profile
    {
        public NotificationMappings()
        {
            CreateMap<EmailNotification, EmailNotificationDto>().ReverseMap();
            CreateMap<SMSNotification, SMSNotificationDto>().ReverseMap();
            CreateMap<WhatsappNotification, WhatsappNotificationDto>().ReverseMap();

        }
    }
}
