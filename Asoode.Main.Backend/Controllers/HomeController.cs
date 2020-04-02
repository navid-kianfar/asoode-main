using System;
using System.Threading.Tasks;
using Asoode.Main.Backend.Filters;
using Asoode.Main.Core.Contracts.Membership;
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
        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult Post()
        {
            return View();
        }
    }
}