using Asoode.Main.Backend.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Asoode.Main.Backend.Controllers
{
    [Localize]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Why()
        {
            return View();
        }
        public IActionResult Plans()
        {
            return View();
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
    }
}