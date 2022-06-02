using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Notification.API.Data;
using Notification.API.Dto;
using Notification.API.Models;
using System.Threading.Tasks;

namespace Notification.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly NotificationContext _db;
        private readonly IMapper _mapper;

        public NotificationsController(NotificationContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("This is notifications service");
        }

        [HttpGet]
        [Route("sms")]
        public async Task<IActionResult> GetSMS()
        {
            return Ok(await _db.SMSNotifications.ToListAsync());
        }

        [HttpGet]
        [Route("email")]
        public async Task<IActionResult> GetEmails()
        {
            return Ok(await _db.EmailNotifications.ToListAsync());
        }

        [HttpPost]
        [Route("sms")]
        public async Task<IActionResult> NotifyViaSMS(SMSNotificationDto smsNotificationDto)
        {
            var notification=_mapper.Map<SMSNotification>(smsNotificationDto);
            //Make call to the message broker here
            await _db.SMSNotifications.AddAsync(notification);
            await _db.SaveChangesAsync();
            return Ok(notification);
        }

        [HttpPost]
        [Route("email")]
        public async Task<IActionResult> NotifyViaEmail(EmailNotificationDto emailNotificationDto)
        {
            var notification = _mapper.Map<EmailNotification>(emailNotificationDto);
            //Make call to the message broker here
            await _db.EmailNotifications.AddAsync(notification);
            await _db.SaveChangesAsync();
            return Ok(notification);
        }
    }
}
