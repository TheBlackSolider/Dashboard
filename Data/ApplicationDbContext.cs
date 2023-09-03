using Dashboard.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Dashboard.Data
{
	public class ApplicationDbContext:DbContext
	{

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
		{

		}
			

		public DbSet<Product> Products { get; set; }
		public DbSet<ProductDetails> ProductDeatails { get; set; }

		public DbSet<Customer> Customers { get; set; }

		public DbSet<Invoice> Invoices { get; set; }

	}
}
