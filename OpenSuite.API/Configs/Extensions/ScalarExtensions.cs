using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Scalar.AspNetCore;

namespace OpenSuite.API.Configs.Extensions
{
    public static class ScalarExtensions
    {
        /// <summary>
        /// Agrega y configura Scalar para la documentación de la API.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddScalarDocumentation(this IServiceCollection services)
        {
            // Registro de Scalar
            services.AddOpenApi();
            return services;
        }

        /// <summary>
        /// Configura el middleware de Scalar para la documentación de la API.
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseScalarDocumentation(this IApplicationBuilder app)
        {
            // Scalar se monta en la raíz
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapOpenApi();
                endpoints.MapScalarApiReference(options => { options.Servers = Array.Empty<ScalarServer>(); });

                app.Use(async (context, next) =>
                {
                    if (context.Request.Path == "/")
                    {
                        // redirigir a la documentación de Scalar
                        context.Response.Redirect("/scalar/v1");
                        return;
                    }

                    await next();
                });
            });
           



            return app;
        }
    }
}
