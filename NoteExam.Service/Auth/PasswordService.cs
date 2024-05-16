using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace NoteExam.Service.Auth;

public class PasswordService : IPasswordService
{
	private readonly IConfiguration _configuration;

	public PasswordService(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	public string GenerateSalt()
	{
		byte[] salt = new byte[128 / 8];
		using RandomNumberGenerator rng = RandomNumberGenerator.Create();
		rng.GetBytes(salt);
		return Convert.ToBase64String(salt);
	}

	public string GetPasswordRequirements(string password)
	{
		return  "Password must be at least 8 characters long\n" +
				"Contain at least one uppercase letter\n" +
				"One lowercase letter\n" +
				"One number\n" +
				"One special character.";
	}

	public string HashPassword(string password, string salt)
	{
		string iterationsString = _configuration["Password:Iterations"]!;
		int iterations = int.Parse(iterationsString);
		using Rfc2898DeriveBytes rfc2898 = new(password, Convert.FromBase64String(salt), iterations, HashAlgorithmName.SHA512);
		byte[] hash = rfc2898.GetBytes(256 / 8);
		return Convert.ToBase64String(hash);
	}

	public bool PasswordMeetsRequirements(string password)
	{
		Regex regex = new("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,}$");
		return regex.IsMatch(password);
	}

	public bool PasswordsMatch(string password, string repeatPassword)
	{
		return password == repeatPassword;
	}

	public bool VerifyPassword(string password, string salt, string hash)
	{
		return HashPassword(password, salt) == hash;
	}
}
