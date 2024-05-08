using _044_Les_Files.DTO;
using _044_Les_Files.Models;
using _044_Les_Files.Services;
using Microsoft.AspNetCore.Mvc;

namespace _044_Les_Files.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class UserController : ControllerBase
{
	private readonly IUserService _userService;

	public UserController(IUserService userService)
	{
		_userService = userService;
	}

	[HttpGet]
	public async Task<IActionResult> GetUsers()
	{
		var users = await _userService.GetUsersAsync();
		return Ok(users);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetUserById(Guid id)
	{
		var user = await _userService.GetUserAsync(id);
		if (user == null)
		{
			return NotFound();
		}
		return Ok(user);
	}

	[HttpPost]
	public async Task<IActionResult> CreateUser([FromBody] User user)
	{
		var newUser = await _userService.AddUserAsync(user);
		return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateUser(Guid id, [FromBody] User user)
	{
		user.Id = id;
		var updatedUser = await _userService.UpdateUserAsync(user);
		if (updatedUser == null)
		{
			return NotFound();
		}
		return Ok(updatedUser);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteUser(Guid id)
	{
		var deletedUser = await _userService.DeleteUserAsync(id);
		if (!deletedUser)
		{
			return NotFound();
		}
		return Ok();
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> SetProfilePicture(Guid id, [FromForm] UploadImageDTO file)
	{
		var user = await _userService.GetUserAsync(id);
		if (user == null)
		{
			return NotFound();
		}
		var filePath = await _userService.SetProfilePictureAsync(id, file.Image);
		return Ok(filePath);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> RemoveProfilePicture(Guid id)
	{
		var user = await _userService.GetUserAsync(id);
		if (user == null)
		{
			return NotFound();
		}
		var deleted = await _userService.RemoveProfilePictureAsync(id);
		if (deleted == null)
		{
			return NotFound();
		}
		return Ok();
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetUserProfilePicture(Guid id)
	{
		var user = await _userService.GetUserAsync(id);
		if (user == null)
		{
			return NotFound();
		}
		var file = await _userService.GetUserProfilePictureAsync(id);
		if (file == null)
		{
			return NotFound();
		}
		return File(file.OpenReadStream(), "image/jpeg");
	}
}
