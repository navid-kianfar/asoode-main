using Asoode.Main.Data.Contexts;
using Microsoft.EntityFrameworkCore;
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
            services.AddDbContextPool<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddTransient<ApplicationDbContext, ApplicationDbContext>();
            return services;
        }
    }
}