using Eskitech.Domain.Exceptions;
using Eskitech.Infrastructure.Repositories;

namespace Eskitech.Entities.Products
{
    public class ProductService(IBaseRepository<Product> productRepository) : IProductService
    {
        private readonly IBaseRepository<Product> _productRepository = productRepository;

        public IEnumerable<Product> GetAllProducts() => 
            _productRepository.GetAll();

        public Product GetProductById(int id) => 
            _productRepository.GetById(id) 
                ?? throw new EntityNotFoundException($"Could not find a product with an Id of '{id}'.");

        public void AddProduct(Product product) => 
            _productRepository.Add(product);

        public void UpdateProduct(Product product) => 
            _productRepository.Update(product);

        public void DeleteProduct(Product product) => 
            _productRepository.Delete(product);
    }
}