using Eskitech.Contracts.Lookup;
using Eskitech.Entities.Categories;

namespace Eskitech.Contracts.Products
{
    public class ProductGetDto
    {
        public int Id { get; set; }

        public string ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Brand { get; set; }

        public LookupDto<Category> Category { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}