using Microsoft.AspNetCore.Mvc;
using MPOS.WebMVC.Data;
using MPOS.WebMVC.ModelsDTO;
using System.Collections;

namespace MPOS.WebMVC.Controllers
{
	public class DashboardController : Controller
	{
		private readonly DemoContext context;

		public DashboardController(DemoContext context)
		{
			this.context = context;
		}
		public IActionResult Index()
		{
			if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")) && string.IsNullOrEmpty(HttpContext.Session.GetString("Password")))
				return RedirectToAction("Index", "User");
			Dashboard dashboard = new Dashboard();
			try
			{
				dashboard.TopProducts = context.VTopProducts.Select(p => new TopProducts
				{
					InvoiceId = p.InvoiceId,
					ProductName = p.ProductName,
					Category = p.Category,
					Quantity = p.Quantity,
					TotalPrice = p.TotalPrice
				}).ToList();


				dashboard.TopEmployees = (
							 from e in context.Employees
							 join s in context.Sales on e.Id equals s.EmployeeId
							 where s.Amount > 900
							 group new { e, s } by new { e.Id, e.Name, e.Phone } into g
							 where g.Sum(x => x.s.Amount) >= 950
							 orderby g.Sum(x => x.s.Amount) descending
							 select new TopEmployees
							 {
								 EmployeeId = g.Key.Id,
								 EmployeeName = g.Key.Name,
								 Phone = g.Key.Phone,
								 TotalAmount = g.Sum(x => x.s.Amount)
							 }
							 ).ToList();

				return View(dashboard);
			}
			catch (Exception ex)
			{
				ViewBag.ErrorMessage = ex.Message;
				return View();
			}

		}
	}
}
