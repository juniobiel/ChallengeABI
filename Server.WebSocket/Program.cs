using WS.Server.Configurations;
using WS.Server.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInjections();

var app = builder.Build();

app.UseWebSockets();

app.MapGet("/", async ( HttpContext context, ChatService chatService ) =>
{
    if (context.WebSockets.IsWebSocketRequest)
    {
        var webSocket = await context.WebSockets.AcceptWebSocketAsync();
        await chatService.HandleWebSocketConnection(webSocket);
    }
    else
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Expected a WebSocket request");
    }
});

await app.RunAsync();
