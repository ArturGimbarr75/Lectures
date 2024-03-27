using _040_Les_Product_API.Models;

namespace _040_Les_Product_API.Repositories;

public interface IProductRepository
{
	Task<IEnumerable<Product>> GetProducts();
	Task<Product?> GetProduct(int id);
	Task<Product> AddProduct(Product product);
	Task<bool> UpdateProduct(Product product);
	Task<bool> DeleteProduct(int id);
	Task<bool> ProductExists(string name);
}
