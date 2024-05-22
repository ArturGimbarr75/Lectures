using Microsoft.AspNetCore.Mvc;
using NoteExam.DTO;
using NoteExam.Models;
using NoteExam.Service.AuthServices;

namespace NoteExam.API.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class AuthController : ControllerBase
{
	private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
		_authService = authService;
	}

	[HttpPost("login")]
	public Task<ActionResult<User?>> Login([FromBody] LoginUserDto loginDto)
	{
		return _authService.LoginAsync(loginDto);
	}

	[HttpPost("register")]
	public Task<ActionResult<User?>> Register([FromBody] RegisterUserDto registerDto)
	{
		return _authService.RegisterAsync(registerDto);
	}

	[HttpPost("refresh")]
	public Task<ActionResult<User?>> Refresh([FromBody] string refreshTokenDto)
	{
		return _authService.UpdateJwtAsync(refreshTokenDto);
	}

	[HttpPost("logout")]
	public Task<ActionResult> Logout([FromBody] string refreshTokenDto)
	{
		return _authService.LogoutAsync(refreshTokenDto);
	}
}
