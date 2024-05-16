using Microsoft.AspNetCore.Mvc;

namespace NoteExam.API.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class AuthController : ControllerBase
{
	[HttpPost("login")]
	public async Task<IActionResult> Login()
	{
		throw new NotImplementedException();
	}
}
