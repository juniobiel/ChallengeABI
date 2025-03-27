using WS.Server.Configurations;
//using WS.Server.Services;
using Server.WebSocket.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInjections();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:8000")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .SetIsOriginAllowed((host) => true)
              .AllowCredentials();
    });

});

builder.Services.AddSignalR();

WebApplication app = builder.Build();

app.UseCors("AllowSpecificOrigin");

app.MapHub<ChatHub>("/chathub");

//app.UseWebSockets();

//TODO: SignalR, HUB
/* app.MapGet("/", async ( HttpContext context, ChatService chatService ) =>
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
}); */


await app.RunAsync();

