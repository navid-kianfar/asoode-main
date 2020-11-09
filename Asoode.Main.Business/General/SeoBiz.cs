using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asoode.Main.Core.Contracts.General;
using Asoode.Main.Core.Contracts.Logging;
using Asoode.Main.Core.Primitives.Enums;
using Asoode.Main.Core.ViewModel.General;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Asoode.Main.Business.General
{
    public class SeoBiz : ISeoBiz
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;

        public SeoBiz(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _serviceProvider = serviceProvider;
            _configuration = configuration;
        }
        public async Task<SiteMapViewModel[]> SiteMap()
        {
            try
            {
                var culture = _configuration["Setting:I18n:Default"];
                var lastModified = new DateTime(2020, 11, 9, 10, 20, 30);
                var baseDomain = _configuration["Setting:Domain"];
                var domain = $"https://{baseDomain}/";
                var domainWithLang = $"https://{baseDomain}/{culture}";
                var result = new List<SiteMapViewModel>
                {
                    new SiteMapViewModel{ Location = $"{domain}", Priority = "1.0", LastModified = lastModified},
                    new SiteMapViewModel{ Location = $"{domainWithLang}", Priority = "0.9", LastModified = lastModified},
                    new SiteMapViewModel{ Location = $"{domainWithLang}/why", Priority = "0.8", LastModified = lastModified},
                    new SiteMapViewModel{ Location = $"{domainWithLang}/plans", Priority = "0.8", LastModified = lastModified},
                    new SiteMapViewModel{ Location = $"{domainWithLang}/faq", Priority = "0.8", LastModified = lastModified},
                    new SiteMapViewModel{ Location = $"{domainWithLang}/contact", Priority = "0.8", LastModified = lastModified},
                    new SiteMapViewModel{ Location = $"{domainWithLang}/about", Priority = "0.8", LastModified = lastModified},
                    new SiteMapViewModel{ Location = $"{domainWithLang}/blog", Priority = "0.8", LastModified = lastModified},
                };

                var posts = await _serviceProvider.GetService<IBlogBiz>().AllPosts(culture);
                foreach (var post in posts.Data)
                {
                    result.Add(new SiteMapViewModel
                    {
                        Priority = "0.7",
                        Location = post.Permalink(baseDomain),
                        LastModified = post.CreatedAt,
                        Title = post.Title
                    });
                }

                return result.ToArray();
            }
            catch (Exception ex)
            {
                await _serviceProvider.GetService<IErrorBiz>().LogException(ex);
                return new SiteMapViewModel[0];
            }
        }

        public async Task<RssViewModel> Rss()
        {
            try
            {
                var culture = _configuration["Setting:I18n:Default"];
                var baseDomain = _configuration["Setting:Domain"];
                var domainWithLang = $"https://{baseDomain}/{culture}";
                var blogBiz = _serviceProvider.GetService<IBlogBiz>();
                var channels = await blogBiz.AllBlogs(culture);
                var posts = await blogBiz.AllPosts(culture);

                var blog = channels.Data.Single(b => b.Type == BlogType.Post);
                return new RssViewModel
                {
                    Description = blog.Description,
                    Link = blog.Permalink(domainWithLang),
                    Title = blog.Title,
                    Items = posts.Data
                        .OrderByDescending(i => i.CreatedAt)
                        .Select(p => new RssItemViewModel
                        {
                            Description = p.Description, Link = p.Permalink(baseDomain), Title = p.Title
                        })
                        .ToArray()
                };
            }
            catch (Exception ex)
            {
                await _serviceProvider.GetService<IErrorBiz>().LogException(ex);
                return null;
            }
        }
    }
}