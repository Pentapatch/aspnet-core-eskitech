using Eskitech.Entities.Products;

namespace Eskitech.Domain.Products
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetAllProductsPaginated(int page, int pageSize);
        Product GetProductById(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        int GetTotalCount();
    }
}