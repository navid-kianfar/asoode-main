using System.Text.Encodings.Web;
using System.Text.Unicode;
using Asoode.Core.Contracts.General;
using Asoode.Main.Backend.Engine;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace Asoode.Web
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection SetupApplicationBackend(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton<IServerInfo, ServerInfo>();
            services.AddSingleton<IJsonBiz, JsonBiz>();
            services.AddSingleton<HtmlEncoder>(
                HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.All }));
            return services;
        }
    }
}