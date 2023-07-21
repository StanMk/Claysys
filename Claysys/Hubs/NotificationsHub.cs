using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Claysys.Hubs
{
    public class NotificationsHub : Hub
    {
        public async Task SendNotification()
        {
            await Clients.All.SendAsync("ReceiveNotification");
        }
    }
}
