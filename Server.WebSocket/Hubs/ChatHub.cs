using Microsoft.AspNetCore.SignalR;

namespace Server.WebSocket.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage( string user, string message, string clientId, string dateTime )
        {
            Console.WriteLine($"Message sended by {user} from {clientId} at {dateTime}");
            await Clients.All.SendAsync("ReceiveMessage", user, message, clientId, dateTime);
        }
    }
    
}