using Datos.ADO;
using Datos.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace OpenSuite.API.Configs.Extensions
{
    /// <summary>
    /// Extensiones para configurar la base de datos y el DbContext.
    /// </summary>
    public static class DatabaseExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // EF DbContext
            services.AddDbContext<OpenSuiteDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Proveedor ADO
            services.AddScoped(sp => new DatosSQL(connectionString));

            // Proveedor EF genérico
            services.AddScoped(typeof(Datos.EF.DatosSQL<>));

            return services;
        }
    }
}
