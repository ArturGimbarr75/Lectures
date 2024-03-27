using _040_Les_Product_API.Models;
using _040_Les_Product_API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _040_Les_Product_API.Services;

public class ProductService : IProductService
{
	private readonly IProductRepository _productRepository;

	public ProductService(IProductRepository productRepository)
	{
		_productRepository = productRepository;
	}

	public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
	{
		var products = await _productRepository.GetProducts();
		ActionResult<IEnumerable<Product>> result = new(products);

		if (products is null)
		{
			result = new NotFoundResult();
		}

		return result;
	}

	public async Task<ActionResult<Product?>> GetProduct(int id)
	{
		var product = await _productRepository.GetProduct(id);
		ActionResult<Product?> result = new(product);

		if (product is null)
		{
			result = new NotFoundResult();
		}

		return result;
	}

	public async Task<ActionResult<Product?>> CreateProduct(Product product)
	{
		if (await _productRepository.ProductExists(product.Name))
		{
			return new ConflictObjectResult("Product already exists");
		}

		if (product.Price < 0)
		{
			return new BadRequestObjectResult("Price cannot be negative");
		}

		if (product.Name.Length < 3)
		{
			return new BadRequestObjectResult("Name must be at least 3 characters long");
		}

		var createdProduct = await _productRepository.AddProduct(product);
		return new(createdProduct);
	}

	public async Task<ActionResult<Product?>> UpdateProductProduct(Product product)
	{
		if (product.Price < 0)
		{
			return new BadRequestObjectResult("Price cannot be negative");
		}

		if (product.Name.Length < 3)
		{
			return new BadRequestObjectResult("Name must be at least 3 characters long");
		}

		var updated = await _productRepository.UpdateProduct(product);
		return !updated ? (ActionResult<Product?>)new NotFoundResult() : new(product);
	}

	public async Task<ActionResult> DeleteProduct(int id)
	{
		var deleted = await _productRepository.DeleteProduct(id);
		return !deleted ? new NotFoundResult() : new OkResult();
	}
}
