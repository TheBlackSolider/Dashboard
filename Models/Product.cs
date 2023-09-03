using System.ComponentModel.DataAnnotations;

namespace Dashboard.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public int ProductNo { get; set; }

        public string? ProductName { get; set; }

        public int OrderNumber { get; set; } // Add this property
    }

}
