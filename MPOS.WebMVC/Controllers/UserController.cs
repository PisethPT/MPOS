using Iu_App_Lecturer.Static;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MPOS.WebMVC.Data;
using MPOS.WebMVC.Models;

namespace MPOS.WebMVC.Controllers
{
	public class UserController : Controller
	{
		private readonly DemoContext context;
		public UserController(DemoContext context)
		{
			this.context = context;
		}
		[HttpGet]
		public IActionResult Index() => View();

		[HttpPost]
		public IActionResult Login(User user)
		{
			try
			{
				if (ModelState.IsValid)
				{
					try
					{
						var existingUser = context.Users.FirstOrDefault(u => u.Username.Equals(user.Username) && u.Password.Equals(Encrypt.Encrypts(user.Password)));
						if (existingUser != null) 
						{
							HttpContext.Session.SetString("Username", existingUser.Username);
							HttpContext.Session.SetString("Password", existingUser.Password);
							return RedirectToAction("Index", "Home");
						}
						else
						{
							ViewBag.Error = "Username or Password not invalid.";
							return View();
						}
					}catch(DbUpdateException ex)
					{
						ViewBag.Error = ex.InnerException!.Message;
						return View();
					}
				}
				else
				{
					ViewBag.Error = "User is empty.";
					return View();
				}
			}
			catch (Exception ex)
			{
				ViewBag.Error = ex.Message;
				return View();
			}
		}

	}
}
