namespace OpenSuite.API.Configs.Extensions
{
    /// <summary>
    /// Extensiones para configurar CORS en la aplicación.
    /// </summary>
    public static class CorsExtensions
    {
        /// <summary>
        /// Agrega y configura CORS para permitir solicitudes desde cualquier origen.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular", policy =>
                {
                    policy.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            return services;
        }
    }
}
