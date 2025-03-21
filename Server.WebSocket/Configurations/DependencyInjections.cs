using WS.Server.Services;

namespace WS.Server.Configurations
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddInjections( this IServiceCollection services )
        {
            services.AddSingleton<ChatService>();
            return services;
        }
    }
}
