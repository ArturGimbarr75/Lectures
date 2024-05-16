using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NoteExam.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NoteExam.Service.Auth;

public class TokenService : ITokenService
{
	private readonly IConfiguration _configuration;

	public TokenService(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	public string GenerateJwt(User user)
	{
		string expirationString = _configuration["JWT:ExpiryMinutes"]!;
		int.TryParse(expirationString, out int expiration);

		List<Claim> claims = new()
		{
			new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
			new Claim(ClaimTypes.Name, user.Username),
			new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddMinutes(expiration).ToString())
		};

		string securityKey = _configuration["JWT:Key"]!;
		SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(securityKey));

		SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);

		JwtSecurityToken token = new(issuer: _configuration["JWT:Issuer"],
										audience: _configuration["JWT:Audience"],
										claims: claims,
										expires: DateTime.Now.AddMinutes(expiration),
										signingCredentials: credentials);

		JwtSecurityTokenHandler tokenHandler = new();
		return tokenHandler.WriteToken(token);
	}

	public string GenerateRefreshToken(User user)
	{
		string expirationString = _configuration["JWT:RefreshTokenExpiryMinutes"]!;
		int.TryParse(expirationString, out int expiration);

		List<Claim> claims = new()
		{
			new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
			new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddMinutes(expiration).ToString())
		};

		string securityKey = _configuration["JWT:RefreshTokenKey"]!;
		SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(securityKey));

		SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);

		JwtSecurityToken token = new(issuer: _configuration["JWT:Issuer"],
										audience: _configuration["JWT:Audience"],
										claims: claims,
										expires: DateTime.Now.AddMinutes(expiration),
										signingCredentials: credentials);

		JwtSecurityTokenHandler tokenHandler = new();
		return tokenHandler.WriteToken(token);
	}

	public (Guid? id, DateTime? exp) GetTokenIdAndExpirationDate(string token)
	{
		var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);

		Claim? idClaim = jwt.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
		Claim? expClaim = jwt.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Expiration);

		Guid? id = idClaim is null ? null : Guid.Parse(idClaim.Value);
		DateTime? exp = expClaim is null ? null : DateTime.Parse(expClaim.Value);

		return (id, exp);
	}

	public Claim[] GetTokenClaims(string token)
	{
		var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);

		return jwt.Claims.ToArray();
	}
}
