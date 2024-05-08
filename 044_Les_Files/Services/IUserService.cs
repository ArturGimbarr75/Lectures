using _044_Les_Files.Models;

namespace _044_Les_Files.Services;

public interface IUserService
{
	Task<User?> GetUserAsync(Guid id);
	Task<User> AddUserAsync(User user);
	Task<User?> UpdateUserAsync(User user);
	Task<IEnumerable<User>> GetUsersAsync();
	Task<User?> SetProfilePictureAsync(Guid id, IFormFile profilePicture);
	Task<User?> RemoveProfilePictureAsync(Guid id);
	Task<IFormFile?> GetUserProfilePictureAsync(Guid id);
	Task<bool> DeleteUserAsync(Guid id);
}
