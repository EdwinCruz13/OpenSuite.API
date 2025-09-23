using Microsoft.OpenApi.Models;

namespace OpenSuite.API.Configs.Extensions
{
    /// <summary>
    /// Extensiones para configurar Swagger en la aplicación.
    /// </summary>
    public static class SwaggerExtensions
    {
        /// <summary>
        /// Agrega y configura Swagger para la documentación de la API.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "OpenSuite API",
                    Version = "v1",
                    Description = "ERP Modular basado en ASP.NET Core"
                });

                // Configuración de seguridad (ejemplo con JWT si aplica)
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header usando el esquema Bearer.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        }, new string[] {}
                    }
                });
            });

            return services;
        }



        /// <summary>
        /// Configura la aplicación para usar Swagger y Swagger UI.
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "OpenSuite API v1");
                c.RoutePrefix = "swagger"; // se abre en /swagger, no en la raíz
            });

            return app;
        }

    }
}
