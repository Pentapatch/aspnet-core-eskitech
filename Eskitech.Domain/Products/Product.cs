using Eskitech.Domain.Categories;
using Eskitech.Domain.Bases;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Eskitech.Domain.Products
{
    public class Product : AuditedEntity
    {
        public string ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Brand { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }
    }
}