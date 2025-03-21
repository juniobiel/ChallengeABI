using System.Net.WebSockets;

namespace WS.Server.Services
{
    public class ChatService
    {
        private readonly List<WebSocket> _sockets = [];

        public async Task HandleWebSocketConnection( WebSocket socket )
        {
            _sockets.Add(socket);

            var buffer = new byte[1024 * 2];

            while (socket.State == WebSocketState.Open)
            {
                var result = await socket.ReceiveAsync(buffer, CancellationToken.None);

                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await socket.CloseAsync(result.CloseStatus.GetValueOrDefault(),
                        result.CloseStatusDescription,
                        CancellationToken.None);
                    break;
                }

                foreach (var s in _sockets)
                    await s.SendAsync(buffer[..result.Count], WebSocketMessageType.Text, true, default);
                
            }
            _sockets.Remove(socket);
        }
    }
}
