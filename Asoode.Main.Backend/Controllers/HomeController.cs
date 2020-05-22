using System;
using System.Threading;
using System.Threading.Tasks;
using Asoode.Main.Backend.Filters;
using Asoode.Main.Core.Contracts.General;
using Asoode.Main.Core.Contracts.Membership;
using Asoode.Main.Core.ViewModel.Blog;
using Asoode.Main.Core.ViewModel.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Asoode.Main.Backend.Controllers
{
    [Localize]
    public class HomeController : Controller
    {
        private readonly IServiceProvider _serviceProvider;

        public HomeController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Why()
        {
            return View();
        }
        public async Task<IActionResult> Plans()
        {
            var op = await _serviceProvider.GetService<IPlanBiz>().List();
            return View(op.Data);
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Faq()
        {
            return View();
        }
        public async Task<IActionResult> Blog(int page = 1)
        {
            var blogBiz = _serviceProvider.GetService<IBlogBiz>();
            var culture = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName.ToLower();
            var blog = await blogBiz.Blog(culture);
            var posts = await blogBiz.Posts(blog.Data.Id, new GridFilter
            {
                Page = page,
                PageSize = 10
            });
            return View(new BlogResultViewModel
            {
                Blog = blog.Data,
                Posts = posts.Data
            });
        }
        
        public async Task<IActionResult> Post(string key, string title)
        {
            var blogBiz = _serviceProvider.GetService<IBlogBiz>();
            var post = await blogBiz.Post(key);
            if (post == null) return Redirect("/");
            return View(post.Data);
        }
    }
}