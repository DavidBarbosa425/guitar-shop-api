using guitar_shop_api.Data;
using guitar_shop_api.Repositories;
using guitar_shop_api.Services;

namespace guitar_shop_api.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {   // Data
            services.AddScoped<DataContext>();
            // Repositories
            services.AddScoped<GuitarRepository>();
            // Services
            services.AddScoped<GuitarService>();
            return services;
        }
    }
}
