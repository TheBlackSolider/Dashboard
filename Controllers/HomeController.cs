using Dashboard.Data;
using Dashboard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Dashboard.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ApplicationDbContext context;

		public HomeController(ApplicationDbContext context)
		{
			this.context = context;
		}

		[Authorize]
		public IActionResult Index()
		{
			var product = context.Products.ToList();

			return View(product);
		}


        public IActionResult AddProduct(Product product)
        {
            // Check if there are any products in the database
            int maxOrderNumber = context.Products.Any() ? context.Products.Max(p => p.OrderNumber) : 0;

            // Set the order number for the new product
            product.OrderNumber = maxOrderNumber + 1;

            // Add the product to the database
            context.Products.Add(product);
            context.SaveChanges();

            return RedirectToAction("Index");
        }






		public IActionResult AddProductDetails(ProductDetails productdetails)
		{
			context.ProductDeatails.Add(productdetails);
			context.SaveChanges();
			return RedirectToAction("Index");
		}








		public IActionResult Edit(int id)
		{
			var product = context.Products.SingleOrDefault(p => p.Id == id);


			return View(product);
		}



		public IActionResult UpdateProducts(Product product)
		{
			Product productupdate = context.Products.SingleOrDefault(p => p.Id == product.Id) ?? new Product();
			if(productupdate!= null)
			{
				productupdate.ProductName = product.ProductName;
				context.SaveChanges();
			}
			
			////context.Products.Update(product);
			/////context.SaveChanges();
			
			return RedirectToAction("Index");

		}





		public IActionResult Delete(int id)
		{
			var product = context.Products.SingleOrDefault(p => p.Id == id);
			if(product != null)
			{
				context.Products.Remove(product);	
				context.SaveChanges();	
			}


			return RedirectToAction("Index");
		}


		public IActionResult Privacy()
		{
			return View();
		}




		public IActionResult ProductDetails()
		{
			
			var productdetails= context.ProductDeatails.ToList();
			ViewBag.ProductDetails = productdetails;
			return View(productdetails);
		}















	
























		[HttpPost]
		public IActionResult ProductDetails(int id)
		{
			var productdetails = context.ProductDeatails.Where(p => p.OrderNumber == id).ToList();
			var product = context.Products.ToList();
			ViewBag.ProductDetails = productdetails;
			return View(product);
		}








































		public IActionResult EditProductDetails(int id)
		{
			var productdetails = context.ProductDeatails.SingleOrDefault(p => p.Id == id);
			TempData["Id"] = id;
			 
			if (productdetails == null)
			{
				return NotFound(); // Handle the case where the product is not found
			
			
			}

			return View(productdetails);
		}




		[HttpPost]
		public IActionResult UpdateProductsDetails(ProductDetails productdetails)
		{
			context.ProductDeatails.Update(productdetails);
			context.SaveChanges();

			return RedirectToAction("ProductDetails");
		}








		public IActionResult DeleteProductDetails(int id)
		{
			var productdetails = context.ProductDeatails.SingleOrDefault(p => p.OrderNumber == id);

		if (productdetails != null)
		{
				context.ProductDeatails.Remove(productdetails);
			context.SaveChanges();
		}
		else
		{
		return NotFound(); // Handle the case where the product is not found
		}

		return RedirectToAction("ProductDetails"); // Redirect to the product list page (or another suitable page)
		}




































		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}