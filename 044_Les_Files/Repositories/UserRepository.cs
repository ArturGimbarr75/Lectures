using _044_Les_Files.Models;
using Microsoft.EntityFrameworkCore;

namespace _044_Les_Files.Repositories;

public class UserRepository : IUserRepository
{
	private readonly AppDbContext _context;

	public UserRepository(AppDbContext context)
	{
		_context = context;
	}

	public async Task<User?> GetUserAsync(Guid id)
	{
		return await _context.Users.FindAsync(id);
	}

	public async Task<User> AddUserAsync(User user)
	{
		var entry = await _context.Users.AddAsync(user);
		await _context.SaveChangesAsync();
		return entry.Entity;
	}

	public async Task<User?> UpdateUserAsync(User user)
	{
		var entry = _context.Users.Update(user);
		await _context.SaveChangesAsync();
		return entry.Entity;
	}

	public async Task<IEnumerable<User>> GetUsersAsync()
	{
		return await _context.Users.ToListAsync();
	}

	public async Task<User?> SetProfilePictureAsync(Guid id, string profilePicture)
	{
		var user = await _context.Users.FindAsync(id);
		if (user == null)
		{
			return null;
		}

		user.ProfilePicturePath = profilePicture;
		await _context.SaveChangesAsync();
		return user;
	}

	public async Task<User?> RemoveProfilePictureAsync(Guid id)
	{
		var user = await _context.Users.FindAsync(id);
		if (user == null)
		{
			return null;
		}

		user.ProfilePicturePath = null;
		await _context.SaveChangesAsync();
		return user;
	}

	public async Task<string?> GetUserProfilePictureAsync(Guid id)
	{
		var user = await _context.Users.FindAsync(id);
		return user?.ProfilePicturePath;
	}

	public async Task<bool> DeleteUserAsync(Guid id)
	{
		var user = await _context.Users.FindAsync(id);
		if (user == null)
		{
			return false;
		}

		_context.Users.Remove(user);
		await _context.SaveChangesAsync();
		return true;
	}

	public async Task<bool> UserExistsAsync(Guid id)
	{
		return await _context.Users.AnyAsync(u => u.Id == id);
	}
}
