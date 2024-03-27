using _040_Les_Product_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace _040_Les_Product_API.Services;

public interface IProductService
{
	Task<ActionResult<IEnumerable<Product>>> GetProducts();
	Task<ActionResult<Product?>> GetProduct(int id);
	Task<ActionResult<Product?>> CreateProduct(Product product);
	Task<ActionResult<Product?>> UpdateProductProduct(Product product);
	Task<ActionResult> DeleteProduct(int id);
}
