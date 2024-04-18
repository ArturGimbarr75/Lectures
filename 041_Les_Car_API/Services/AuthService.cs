using _041_Les_Car_API.Models;
using _041_Les_Car_API.Repositories;

namespace _041_Les_Car_API.Services;

public class AuthService : IAuthService
{
	private readonly IAccountRepository _accountRepository;
	private readonly IPasswordHasher _passwordHasher;
	private readonly IJWTService _jwtServices;

	public AuthService( IPasswordHasher passwordHasher,
						IAccountRepository accountRepository,
						IJWTService jwtServices)
	{
		_passwordHasher = passwordHasher;
		_accountRepository = accountRepository;
		_jwtServices = jwtServices;
	}

	public async Task<Account> SignUp(string name, string password)
	{
		_passwordHasher.CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
		var account = new Account
		{
			Name = name,
			PasswordHash = passwordHash,
			PasswordSalt = passwordSalt
		};

		await _accountRepository.AddAccountAsync(account);
		return account;
	}

	public async Task<(string jwt, string refresh)> LogIn(string name, string password)
	{
		Account? account = await _accountRepository.GetAccountByNameAsync(name);
		if (account is null)
			return (string.Empty, string.Empty);

		bool verified = _passwordHasher.VerifyPasswordHash(password, account.PasswordHash, account.PasswordSalt);
		if (!verified)
			return (string.Empty, string.Empty);

		account.JwtToken = _jwtServices.GenerateSecurityToken(account);
		account.RefreshToken = _jwtServices.GenerateRefreshToken(account);

		await _accountRepository.UpdateAccountAsync(account);

		return (account.JwtToken, account.RefreshToken);
	}
}
