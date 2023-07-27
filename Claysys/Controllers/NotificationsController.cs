using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Claysys.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Claysys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IHubContext<NotificationsHub> _hubContext;
        private static int _unreadCount = 1; // Initial unread count
        private static int _initialUnreadCount = 1;
        public NotificationsController(IHubContext<NotificationsHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet("unread")]
        public IActionResult GetUnreadNotificationCount()
        {
            return Ok(new { unreadCount = _unreadCount });
        }

        [HttpPost("send")]
        public IActionResult SendNotification()
        {
            _unreadCount++;
            _hubContext.Clients.All.SendAsync("ReceiveNotification");
            return Ok(new { message = "Notification sent successfully.", unreadCount = _unreadCount });
        }

        [HttpPost("reset")]
        public IActionResult ResetNotifications()
        {
            _unreadCount = _initialUnreadCount;
            return Ok(new { message = "Notifications reset successfully.", unreadCount = _unreadCount });
        }

    }
}
