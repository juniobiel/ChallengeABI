namespace WS.Server.Configurations
{
    public static class CorsPolicies 
    {
        public static IServiceCollection AddCorsPolicies(this IServiceCollection services)
        {
            services.AddCors(options =>
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

            return services;
        }
    }
}
