using System.ComponentModel.DataAnnotations;

namespace Eskitech.Contracts.Products
{
    public class ProductCreateDto
    {
        [Required]
        public string ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int StockQuantity { get; set; }
    }
}