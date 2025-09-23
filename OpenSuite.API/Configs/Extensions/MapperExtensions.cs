namespace OpenSuite.API.Configs.Extensions
{
    public static class MapperExtensions
    {
        /// <summary>
        /// Add AutoMapper to the service collection
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            // Register AutoMapper with all assemblies in the current domain
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}
