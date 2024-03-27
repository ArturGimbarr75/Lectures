using _040_Les_Product_API.Models;
using _040_Les_Product_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace _040_Les_Product_API.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

	public ProductController(IProductService productService)
	{
		_productService = productService;
	}

	[HttpGet(Name = nameof(GetProducts))]
	public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
	{
		return await _productService.GetProducts();
	}

	[HttpGet("{id}", Name = nameof(GetProduct))]
	public async Task<ActionResult<Product?>> GetProduct(int id)
	{
		return await _productService.GetProduct(id);
	}

	[HttpPost(Name = nameof(CreateProduct))]
	public async Task<ActionResult<Product?>> CreateProduct(Product product)
	{
		return await _productService.CreateProduct(product);
	}

	[HttpPut(Name = nameof(UpdateProduct))]
	public async Task<ActionResult<Product?>> UpdateProduct(Product product)
	{
		return await _productService.UpdateProductProduct(product);
	}

	[HttpDelete(Name = nameof(DeleteProduct))]
	public async Task<ActionResult> DeleteProduct(int id)
	{
		return await _productService.DeleteProduct(id);
	}
}
