using Negocio.Modulos.Catalogos;
using Negocio.Modulos.Configuraciones.Empresas;
using Negocio.Modulos.Finanzas.Comprobantes;
using Negocio.Modulos.Finanzas.PlanCuentas;
using Negocio.Modulos.Personas;
using Negocio.Modulos.Seguridad.Auth;
using Negocio.Modulos.Seguridad.Modulos;
using Negocio.Modulos.Seguridad.Usuarios;

namespace OpenSuite.API.Configs.Extensions
{
    /// <summary>
    /// Extensiones para registrar servicios de negocio
    /// </summary>
    public static class BusinessExtensions
    {
        /// <summary>
        /// Registra los servicios de negocio en el contenedor de dependencias
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            /// Dependencia de negocio



            // Finanzas
            services.AddScoped<PlanCuentasServicios>();
            services.AddScoped<ComprobantesServicios>();
            // Catálogos
            services.AddScoped<CatalogosServicios>();
            // Configuración de Empresas
            services.AddScoped<EmpresasServicios>();
            // Seguridad
            services.AddScoped<UsuariosServicios>();
            // Personas
            services.AddScoped<PersonasServicios>();



            //seguridad
            services.AddScoped<ModulosServicios>();
            services.AddScoped<AuthServicios>();



            /// Dependencia de herramientas
            return services;
        }
    }
}
