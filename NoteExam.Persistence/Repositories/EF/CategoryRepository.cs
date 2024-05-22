using Microsoft.EntityFrameworkCore;
using NoteExam.Models;
using NoteExam.Persistence.Context;

namespace NoteExam.Persistence.Repositories.EF;

public class CategoryRepository : ICategoryRepository
{
	private readonly AppDbContext _context;

	public CategoryRepository(AppDbContext context)
	{
		_context = context;
	}

	public async Task<Category?> AddCategoryAsync(Category category)
	{
		try
		{
			_context.Categories.Add(category);
			await _context.SaveChangesAsync();
			return category;
		}
		catch (Exception)
		{
			return null;
		}
	}

	public async Task<bool> DeleteCategoryAsync(Guid id)
	{
		Category? foundCategory = _context.Categories.Find(id);

		if (foundCategory is null)
		{
			return false;
		}

		_context.Categories.Remove(foundCategory);
		await _context.SaveChangesAsync();

		return true;
	}

	public async Task<IEnumerable<Category>> GetAllUserCategoriesAsync(Guid userId)
	{
		return await _context.Categories.Where(c => c.UserId == userId).ToListAsync();
	}

	public async Task<Category?> GetCategoryByIdAsync(Guid id)
	{
		return await _context.Categories.FindAsync(id);
	}

	public async Task<bool> IsUserOwnsCategoryAsync(Guid userId, Guid categoryId)
	{
		return await _context.Categories.AnyAsync(c => c.UserId == userId && c.Id == categoryId);
	}

	public async Task<Category?> UpdateCategoryAsync(Category category)
	{
		Category? foundCategory = _context.Categories.Find(category.Id);

		if (foundCategory is null)
		{
			return null;
		}

		_context.Entry(foundCategory).CurrentValues.SetValues(category);
		_context.Categories.Update(foundCategory);
		await _context.SaveChangesAsync();

		return foundCategory;
	}
}
