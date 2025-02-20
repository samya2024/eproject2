using System.Diagnostics;
using eproject2.Models;
using Microsoft.AspNetCore.Mvc;

namespace eproject2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult aboutus()
        {
            return View();
        }
        public IActionResult Listing()
        {
            return View();
        }
        public IActionResult ListingDetails()
        {

            return View();
        }
        public IActionResult Agent()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
