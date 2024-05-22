using NoteExam.Models;

namespace NoteExam.Persistence.Repositories;

public interface ICategoryRepository
{
	Task<bool> IsUserOwnsCategoryAsync(Guid userId, Guid categoryId);
	Task<IEnumerable<Category>> GetAllUserCategoriesAsync(Guid userId);
	Task<Category?> GetCategoryByIdAsync(Guid id);
	Task<Category?> AddCategoryAsync(Category category);
	Task<Category?> UpdateCategoryAsync(Category category);
	Task<bool> DeleteCategoryAsync(Guid id);
}
