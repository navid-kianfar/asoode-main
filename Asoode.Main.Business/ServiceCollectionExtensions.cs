using Asoode.Main.Business.General;
using Asoode.Main.Business.Logging;
using Asoode.Main.Business.Membership;
using Asoode.Main.Core.Contracts.General;
using Asoode.Main.Core.Contracts.Logging;
using Asoode.Main.Core.Contracts.Membership;
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
            services.AddTransient<IBlogBiz, BlogBiz>();
            services.AddTransient<IPlanBiz, PlanBiz>();
            services.AddTransient<IErrorBiz, ErrorBiz>();
            return services;
        }
    }
}