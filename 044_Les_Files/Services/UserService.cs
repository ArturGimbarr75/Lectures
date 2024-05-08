using _044_Les_Files.Models;
using _044_Les_Files.Repositories;

namespace _044_Les_Files.Services;

public class UserService : IUserService
{
	private readonly IUserRepository _userRepository;
	private const string PROFILE_PICTURE_FOLDER = "profile-pictures";

	public UserService(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	public async Task<User?> GetUserAsync(Guid id)
	{
		return await _userRepository.GetUserAsync(id);
	}

	public async Task<User> AddUserAsync(User user)
	{
		return await _userRepository.AddUserAsync(user);
	}

	public async Task<User?> UpdateUserAsync(User user)
	{
		return await _userRepository.UpdateUserAsync(user);
	}

	public async Task<IEnumerable<User>> GetUsersAsync()
	{
		return await _userRepository.GetUsersAsync();
	}

	public async Task<User?> SetProfilePictureAsync(Guid id, IFormFile profilePicture)
	{
		var user = await _userRepository.GetUserAsync(id);
		if (user == null)
		{
			return null;
		}

		var profilePicturePath = Path.Combine(PROFILE_PICTURE_FOLDER, $"{id}{Path.GetExtension(profilePicture.FileName)}");
		using (var stream = new FileStream(profilePicturePath, FileMode.Create))
		{
			await profilePicture.CopyToAsync(stream);
		}

		user.ProfilePicturePath = profilePicturePath;
		return await _userRepository.UpdateUserAsync(user);
	}

	public async Task<User?> RemoveProfilePictureAsync(Guid id)
	{
		var user = await _userRepository.GetUserAsync(id);
		if (user == null)
		{
			return null;
		}

		if (File.Exists(user.ProfilePicturePath))
		{
			File.Delete(user.ProfilePicturePath);
		}

		user.ProfilePicturePath = null;
		return await _userRepository.UpdateUserAsync(user);
	}

	public async Task<IFormFile?> GetUserProfilePictureAsync(Guid id)
	{
		var user = await _userRepository.GetUserAsync(id);
		if (user == null || user.ProfilePicturePath == null)
		{
			return null;
		}

		return new FormFile(new FileStream(user.ProfilePicturePath, FileMode.Open), 0, new FileInfo(user.ProfilePicturePath).Length, "ProfilePicture", Path.GetFileName(user.ProfilePicturePath));
	}

	public async Task<bool> DeleteUserAsync(Guid id)
	{
		var user = await _userRepository.GetUserAsync(id);
		if (user == null)
		{
			return false;
		}

		if (user.ProfilePicturePath != null && File.Exists(user.ProfilePicturePath))
		{
			File.Delete(user.ProfilePicturePath);
		}

		return await _userRepository.DeleteUserAsync(id);
	}
}