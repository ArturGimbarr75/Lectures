using Microsoft.EntityFrameworkCore;
using NoteExam.Models;
using NoteExam.Persistence.Context;

namespace NoteExam.Persistence.Repositories.EF;

public class UserRepository : IUserRepository
{
	private readonly AppDbContext _context;

	public UserRepository(AppDbContext context)
	{
		_context = context;
	}

	public async Task<User?> AddUserAsync(User user)
	{
		await _context.Users.AddAsync(user);
		await _context.SaveChangesAsync();

		return user;
	}

	public async Task<bool> DeleteUserAsync(Guid id)
	{
		User? user = await _context.Users.FindAsync(id);

		if (user is null)
			return false;

		var entity = _context.Users.Remove(user);
		await _context.SaveChangesAsync();

		return entity.State == EntityState.Deleted;
	}

	public async Task<User?> GetUserByIdAsync(Guid id)
	{
		return await _context.Users.FindAsync(id);
	}

	public Task<User?> GetUserByUsernameAsync(string username)
	{
		return _context.Users.FirstOrDefaultAsync(u => u.Username == username);
	}

	public async Task<IEnumerable<User>> GetUsersAsync(int skip, int take)
	{
		return await _context.Users.Skip(skip).Take(take).ToListAsync();
	}

	public Task<User?> UpdateUserAsync(User user)
	{
		User? foundUser = _context.Users.Find(user.Id);

		if (foundUser is null)
			return Task.FromResult<User?>(null);

		_context.Entry(foundUser).CurrentValues.SetValues(user);
		_context.Update(foundUser);
		_context.SaveChanges();

		return Task.FromResult<User?>(foundUser);
	}
}
