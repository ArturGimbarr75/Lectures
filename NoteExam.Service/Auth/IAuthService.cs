using NoteExam.Models;
using Microsoft.AspNetCore.Mvc;
using NoteExam.DTO;

namespace NoteExam.Service.Auth;

public interface IAuthService
{
	Task<ActionResult<User?>> RegisterAsync(RegistrationUserDto user);
	Task<ActionResult<User?>> LoginAsync(LoginUserDto user);
	Task<ActionResult<User?>> UpdateJwtAsync(string refreshToken);
	Task<ActionResult<User?>> LogoutAsync(string refreshToken);
}
