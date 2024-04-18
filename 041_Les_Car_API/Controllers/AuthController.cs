using _041_Les_Car_API.DTO;
using _041_Les_Car_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace _041_Les_Car_API.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AuthController : Controller
{
	private readonly IAuthService _authService;

	public AuthController(IAuthService authService)
	{
		_authService = authService;
	}

	[HttpPost(Name = "SignUp")]
	public async Task<IActionResult> SignUp([FromBody] LoginDto registerDto)
	{
		var result = _authService.SignUp(registerDto.Name, registerDto.Password);
		if (result is null)
			return BadRequest();

		return Ok(result);
	}

	[HttpPost(Name = "LogIn")]
	public async Task<ActionResult<Tokens>> LogIn([FromBody] LoginDto loginDto)
	{
		var result = await _authService.LogIn(loginDto.Name, loginDto.Password);
		if (result.jwt is null)
			return Unauthorized();

		Tokens tokens = new()
		{
			Jwt = result.jwt,
			Refresh = result.refresh
		};
		return Ok(tokens);
	}
}
