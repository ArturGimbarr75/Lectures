using _044_Les_Files.Models;

namespace _044_Les_Files.Repositories;

public interface IUserRepository
{
	Task<User?> GetUserAsync(Guid id);
	Task<User> AddUserAsync(User user);
	Task<User?> UpdateUserAsync(User user);
	Task<IEnumerable<User>> GetUsersAsync();
	Task<User?> SetProfilePictureAsync(Guid id, string profilePicture);
	Task<User?> RemoveProfilePictureAsync(Guid id);
	Task<string?> GetUserProfilePictureAsync(Guid id);
	Task<bool> DeleteUserAsync(Guid id);
}
