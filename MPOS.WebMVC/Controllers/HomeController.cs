using System.Collections;
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
            IEnumerable products = from product in context.Products
                           join category in context.Categories
                           on product.CategoryId equals category.Id
                           select new
                           {
                               Id  = product.Id,
                               Name = product.Name,
                               Category = category!.Name,
                               CostPrice = product.CostPrice,
                               SellingPrice = product.SellingPrice,
                               Unit = product.Unit
                           };
                           
            return View(products);
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
