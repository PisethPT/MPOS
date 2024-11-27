using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MPOS.WebMVC.Data;
using MPOS.WebMVC.Models;
using System.Collections;



namespace MPOS.WebMVC.Controllers
{
	public class ProductController : Controller
	{
		private readonly DemoContext context;
		private readonly IFileService fileService;
		private IWebHostEnvironment webHostEnvironment;
		public ProductController(DemoContext context, IFileService fileService, IWebHostEnvironment webHostEnvironment)
		{
			this.context = context;
			this.fileService = fileService;
			this.webHostEnvironment = webHostEnvironment;
		}

		[HttpGet]
		public ActionResult ViewProducts() 
		{
			if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")) && string.IsNullOrEmpty(HttpContext.Session.GetString("Password")))
				return RedirectToAction("Index", "User");

			return View(Products()); 
		}

		[HttpGet]
		public ActionResult Product(Product product)
		{
			if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")) && string.IsNullOrEmpty(HttpContext.Session.GetString("Password")))
				return RedirectToAction("Index", "User");

			if (product.Id > 0)
			{
				var existingProduct = context.Products.FirstOrDefault(p => p.Id == product.Id);
				existingProduct = GetCategoriesItem(existingProduct!, "Update Product");
				return View(existingProduct);
			}
			else
			{
				product = GetCategoriesItem(product!, "Create Product");
				return View(product);
			}
		}

		[HttpPost]
		public ActionResult CreateProduct(Product newProduct)
		{
			if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")) && string.IsNullOrEmpty(HttpContext.Session.GetString("Password")))
				return RedirectToAction("Index", "User");

			try
			{
				if(newProduct is not null)
				{
					newProduct.Created = DateTime.Now;
					newProduct.Updated = DateTime.Now;
					if(newProduct.IPhoto is not null)
					{
						var file = fileService.GetFile(newProduct.IPhoto);
						if (file != null)
							newProduct.Photo = file.Item1 as string;
					}

					context.Products.Add(newProduct);
					context.SaveChanges();
					ViewBag.info = "Product Created.";
					return View("ViewProducts", Products());
				}
				else
				{
					ViewBag.error = "Product is null";
					newProduct = GetCategoriesItem(newProduct!, "Create Product");
					return View("Product", newProduct);
				}

			}catch(DbUpdateException ex)
			{
				ViewBag.error = ex.InnerException?.Message;
				newProduct = GetCategoriesItem(newProduct, "Create Product");
				return View("Product", newProduct);
			}
		}

		[HttpPost]
		public ActionResult EditProduct(Product newProduct) 
		{
			if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")) && string.IsNullOrEmpty(HttpContext.Session.GetString("Password")))
				return RedirectToAction("Index", "User");

			try
			{
				var existingProduct = context.Products.FirstOrDefault(p => p.Id.Equals(newProduct.Id));
				if (existingProduct is not null)
				{
					if (newProduct.IPhoto is not null)
					{
						var file = fileService.GetFile(newProduct.IPhoto);
						if (file != null)
							existingProduct.Photo = file.Item1 as string;
					}

					existingProduct.Name = newProduct.Name;
					existingProduct.CategoryId = newProduct.CategoryId;
					existingProduct.CostPrice = newProduct.CostPrice;
					existingProduct.SellingPrice = newProduct.SellingPrice;
					existingProduct.Unit = newProduct.Unit;
					existingProduct.Updated = DateTime.Now;

					context.SaveChanges();
					ViewBag.info = "Product Updated.";
					return View("ViewProducts", Products());
				}
				else
				{
					ViewBag.error = "Product not found.";
					newProduct = GetCategoriesItem(newProduct!, "Update Product");
					return View("Product", newProduct);
				}

			}
			catch (DbUpdateException ex)
			{
				ViewBag.error = ex.InnerException?.Message;
				newProduct = GetCategoriesItem(newProduct, "Update Product");
				return View("Product", newProduct);
			}
		}

		private Product GetCategoriesItem(Product product, string title)
		{
			product.Title = title;
			product.Categories = context.Categories.Select(c => new SelectListItem
			{
				Value = c.Id.ToString(),
				Text = c.Name,
			}).ToList();

			return product;
		}

		private IEnumerable Products()
		{
			return (from product in context.Products
									join category in context.Categories
									on product.CategoryId equals category.Id
									select new
									{
										Id = product.Id,
										Name = product.Name,
										Category = category!.Name,
										CostPrice = product.CostPrice,
										SellingPrice = product.SellingPrice,
										Unit = product.Unit,
										Photo = product.Photo
									}).AsEnumerable().ToList();
		}
	}
}
