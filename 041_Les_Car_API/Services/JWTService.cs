using _041_Les_Car_API.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _041_Les_Car_API.Services;

public class JWTService : IJWTService
{
	private readonly IConfiguration _configuration;

	public JWTService(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	public string GenerateSecurityToken(Account account)
	{
		int expiration = _configuration.GetValue<int>("JWT:AccessExpiration");

		List<Claim> claims = new()
		{
			new Claim(ClaimTypes.Name, account.Name),
			new Claim(ClaimTypes.Role, account.Role),
			new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
			new Claim(ClaimTypes.Expiration, DateTime.Now.AddMinutes(expiration).ToString())
		};

		string securityKey = _configuration["JWT:Key"]!;
		SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(securityKey));

		SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);

		JwtSecurityToken token = new(	issuer: _configuration["JWT:Issuer"],
										audience: _configuration["JWT:Audience"],
										claims: claims,
										expires: DateTime.Now.AddMinutes(expiration),
										signingCredentials: credentials);

		JwtSecurityTokenHandler tokenHandler = new();
		return tokenHandler.WriteToken(token);
	}

	public string GenerateRefreshToken(Account account)
	{
		int refreshExpiration = _configuration.GetValue<int>("JWT:RefreshExpiration");

		List<Claim> claims = new()
		{
			new Claim(ClaimTypes.Name, account.Name),
			new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
			new Claim(ClaimTypes.Expiration, DateTime.Now.AddMinutes(refreshExpiration).ToString())
		};

		string securityKey = _configuration["JWT:Key"]!;
		SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(securityKey));

		SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);

		JwtSecurityToken token = new(	issuer: _configuration["JWT:Issuer"],
										audience: _configuration["JWT:Audience"],
										claims: claims,
										expires: DateTime.Now.AddMinutes(refreshExpiration),
										signingCredentials: credentials);

		JwtSecurityTokenHandler tokenHandler = new();
		return tokenHandler.WriteToken(token);
	}
}