using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MPOS.WebMVC.Data;
using MPOS.WebMVC.Models;

namespace MPOS.WebMVC.Controllers
{
	public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DemoContext context;
        public HomeController(ILogger<HomeController> logger, DemoContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
			if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")) && string.IsNullOrEmpty(HttpContext.Session.GetString("Password")))
				return RedirectToAction("Index", "User");

			return View();
        }

        public IActionResult Privacy()
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
