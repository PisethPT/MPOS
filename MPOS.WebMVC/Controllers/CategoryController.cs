using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MPOS.WebMVC.Data;

namespace MPOS.WebMVC.Controllers
{
	public class CategoryController : Controller
	{
		private readonly DemoContext context;

		public CategoryController(DemoContext context)
		{
			this.context = context;
		}
		public IActionResult ViewCategories()
		{
			if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")) && string.IsNullOrEmpty(HttpContext.Session.GetString("Password")))
				return RedirectToAction("Index", "User");

			try
			{
				var categeries = context.Categories.ToList();
				return View(categeries);
			}
			catch (DbUpdateException ex)
			{
				ViewBag.ErrorMessage = ex.Message;
				return View();
			}
		}
	}
}
