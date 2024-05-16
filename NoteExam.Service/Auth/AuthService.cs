using Microsoft.AspNetCore.Mvc;
using NoteExam.DTO;
using NoteExam.Models;
using NoteExam.Persistence.Repositories;

namespace NoteExam.Service.Auth;

public class AuthService : IAuthService
{
	private readonly IUserRepository _userRepository;
	private readonly ITokenService _tokenService;
	private readonly IPasswordService _passwordService;

	public AuthService(IUserRepository userRepository, ITokenService jwtService, IPasswordService passwordService)
	{
		_userRepository = userRepository;
		_tokenService = jwtService;
		_passwordService = passwordService;
	}

	public async Task<ActionResult<User?>> LoginAsync(LoginUserDto user)
	{
		User? existingUser = await _userRepository.GetUserByUsernameAsync(user.Username);

		if (existingUser is null)
		{
			return new NotFoundObjectResult("User not found");
		}

		if (!_passwordService.VerifyPassword(user.Password, existingUser.PasswordSalt, existingUser.PasswordHash))
		{
			return new UnauthorizedObjectResult("Invalid password");
		}

		string jwt = _tokenService.GenerateJwt(existingUser);
		string refreshToken = _tokenService.GenerateRefreshToken(existingUser);

		User updatedUser = new()
		{
			Id = existingUser.Id,
			Username = existingUser.Username,
			PasswordHash = existingUser.PasswordHash,
			PasswordSalt = existingUser.PasswordSalt,
			RefreshToken = refreshToken,
			JwtToken = jwt
		};

		User? updatedUserResult = await _userRepository.UpdateUserAsync(updatedUser);

		if (updatedUserResult is null)
		{
			return new StatusCodeResult(500);
		}

		return updatedUserResult;
	}

	public Task<ActionResult<User?>> LogoutAsync(string refreshToken)
	{
		throw new NotImplementedException();
	}

	public async Task<ActionResult<User?>> RegisterAsync(RegistrationUserDto user)
	{
		User? existingUser = await _userRepository.GetUserByUsernameAsync(user.Username);
		if (existingUser is not null)
		{
			return new ConflictObjectResult("User with this username already exists");
		}

		if (!_passwordService.PasswordMeetsRequirements(user.Password))
		{
			return new BadRequestObjectResult($"Password is not strong enough." +
				$"{_passwordService.GetPasswordRequirements(user.Password)}");
		}
		
		if (user.Password != user.ConfirmPassword)
		{
			return new BadRequestObjectResult("Passwords do not match");
		}

		string salt = _passwordService.GenerateSalt();
		string passwordHash = _passwordService.HashPassword(user.Password, salt);

		User newUser = new()
		{
			Username = user.Username,
			PasswordHash = passwordHash,
			PasswordSalt = salt,
			RefreshToken = null,
			JwtToken = null
		};
		
		User? registeredUser = await _userRepository.AddUserAsync(newUser);

		if (registeredUser is null)
		{
			// 500 Internal Server Error
			return new StatusCodeResult(500);
		}

		return registeredUser;
	}

	public async Task<ActionResult<User?>> UpdateJwtAsync(string refreshToken)
	{
		var (userId, expirationDate) = _tokenService.GetTokenIdAndExpirationDate(refreshToken);

		if (userId is null || expirationDate is null)
		{
			return new UnauthorizedObjectResult("Invalid refresh token");
		}

		if (expirationDate < DateTime.UtcNow)
		{
			return new UnauthorizedObjectResult("Refresh token expired");
		}

		User? existingUser = await _userRepository.GetUserByIdAsync(userId.Value);

		if (existingUser is null)
		{
			return new NotFoundObjectResult("User not found");
		}

		if (existingUser.RefreshToken != refreshToken)
		{
			return new UnauthorizedObjectResult("Invalid refresh token");
		}

		string jwt = _tokenService.GenerateJwt(existingUser);

		User updatedUser = new()
		{
			Id = existingUser.Id,
			Username = existingUser.Username,
			PasswordHash = existingUser.PasswordHash,
			PasswordSalt = existingUser.PasswordSalt,
			RefreshToken = refreshToken,
			JwtToken = jwt
		};

		User? updatedUserResult = await _userRepository.UpdateUserAsync(updatedUser);

		if (updatedUserResult is null)
		{
			return new StatusCodeResult(500);
		}

		return updatedUserResult;
	}
}
