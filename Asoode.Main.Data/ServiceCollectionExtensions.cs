using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Asoode.Main.Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection SetupApplicationData(
            this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            return services;
        }
    }
}