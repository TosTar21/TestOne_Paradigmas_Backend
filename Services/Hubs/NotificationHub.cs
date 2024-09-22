using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Services.Hubs
{
    public class NotificationHub : Hub
    {
        // Método que se puede llamar desde el cliente para enviar mensajes
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
