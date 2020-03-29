using Asoode.Core.Contracts.General;
using Asoode.Main.Business.General;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Asoode.Main.Business
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection SetupApplicationBusiness(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ITranslateBiz, TranslateBiz>();
            return services;
        }
    }
}