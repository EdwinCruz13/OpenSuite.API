using Shared.Encrypt;
using OpenSuite.API.Tools.Responses;

namespace OpenSuite.API.Configs.Extensions
{
    /// <summary>
    /// Extensiones para registrar servicios de herramientas
    /// </summary>
    public static class ToolExtensions
    {
        /// <summary>
        /// Registra los servicios de herramientas en el contenedor de dependencias
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddTools(this IServiceCollection services)
        {
            services.AddScoped<PasswordService>();
            services.AddScoped<ResponseService>();
            services.AddScoped<IResponseService, ResponseService>();


            /// Dependencia de herramientas
            return services;
        }
    }
}

