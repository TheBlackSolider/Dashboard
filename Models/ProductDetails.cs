using System.ComponentModel.DataAnnotations;

namespace Dashboard.Models
{
	public class ProductDetails
	{
		[Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? ProductDescription { get; set; }
        public string? AutherName { get; set; }
		public string? Type { get; set; }
		public string? ReleaseDate { get; set; }
		public int QTY { get; set; }
		public string? Price { get; set; }
        public string? Image { get; set; }

		public int OrderNumber { get; set; } // Add this property


	}
}
