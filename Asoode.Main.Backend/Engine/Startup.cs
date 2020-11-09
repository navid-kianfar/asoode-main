using Asoode.Main.Business;
using Asoode.Main.Data;
using Asoode.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Asoode.Main.Backend.Engine
{
    public class I18NRouteConstraint : RegexRouteConstraint
    {
        public I18NRouteConstraint() : 
            base(@"(fa|en|ar|fr|it|lv|nl|es|ru|ms|da|pt|sv|de|tr|ga|fi|hi)$")
        {
        }
    }
    
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.SetupApplicationData(Configuration);
            services.SetupApplicationBusiness(Configuration);
            services.SetupApplicationBackend(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "sitemap", 
                    "sitemap.xml", 
                    new { controller = "Home", action = "SiteMap" }
                );
                endpoints.MapControllerRoute(
                    "root", 
                    "{culture?}", 
                    new { controller = "Home", action = "Index" }, 
                    new { culture = new I18NRouteConstraint() }
                );
                endpoints.MapControllerRoute(
                    "main", 
                    "{culture}/{action=Index}/{id?}", 
                    new { controller = "Home" }, 
                    new { culture = new I18NRouteConstraint() }
                );
                endpoints.MapControllerRoute(
                    "posts", 
                    "{culture}/post/{key}/{title}", 
                    new { controller = "Home", action = "Post" }, 
                    new { culture = new I18NRouteConstraint() }
                );
            });
        }
    }
}