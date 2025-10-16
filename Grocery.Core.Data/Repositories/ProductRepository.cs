using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class ProductRepository : DatabaseConnection, IProductRepository
    {
        private readonly List<Product> _products = [];
        
        public ProductRepository()
        {
            _products = [
                new Product(1, "Melk", 300, new DateOnly(2025, 9, 25), 0.95m),
                new Product(2, "Kaas", 100, new DateOnly(2025, 9, 30), 7.98m),
                new Product(3, "Brood", 400, new DateOnly(2025, 9, 12), 2.19m),
                new Product(4, "Cornflakes", 0, new DateOnly(2025, 12, 31), 1.48m)];
        }
        public List<Product> GetAll()
        {
            return _products;
        }

        public Product? Get(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public Product Add(Product item)
        {
            throw new NotImplementedException();
        }

        public Product? Delete(Product item)
        {
            throw new NotImplementedException();
        }

        public Product? Update(Product item)
        {
            Product? product = _products.FirstOrDefault(p => p.Id == item.Id);
            if (product == null) return null;
            product.Id = item.Id;
            return product;
        }
    }
}
