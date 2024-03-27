﻿using _040_Les_Product_API.Models;
using Microsoft.EntityFrameworkCore;

namespace _040_Les_Product_API.Repositories;

public class ProductRepository : IProductRepository
{
	private readonly ApplicationDbContext _context;

	public ProductRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<Product>> GetProducts()
	{
		return await _context.Products.ToListAsync();
	}

	public async Task<Product?> GetProduct(int id)
	{
		return await _context.Products.FindAsync(id);
	}

	public async Task<Product> AddProduct(Product product)
	{
		_context.Products.Add(product);
		await _context.SaveChangesAsync();
		return product;
	}

	public async Task<bool> UpdateProduct(Product product)
	{
		var existingProduct = await _context.Products.FindAsync(product.Id);
		if (existingProduct is null)
			return false;

		existingProduct.Name = product.Name;
		existingProduct.Price = product.Price;

		await _context.SaveChangesAsync();
		return true;
	}

	public async Task<bool> DeleteProduct(int id)
	{
		var product = await _context.Products.FindAsync(id);
		if (product == null)
		{
			return false;
		}

		_context.Products.Remove(product);
		await _context.SaveChangesAsync();
		return true;
	}

	public async Task<bool> ProductExists(string name)
	{
		return await _context.Products.AnyAsync(e => e.Name == name);
	}
}
