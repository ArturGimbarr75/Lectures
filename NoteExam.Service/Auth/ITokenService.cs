using NoteExam.Models;
using System.Security.Claims;

namespace NoteExam.Service.Auth;

public interface ITokenService
{
	string GenerateJwt(User user);
	string GenerateRefreshToken(User user);
	(Guid? id, DateTime? exp) GetTokenIdAndExpirationDate(string token);
	Claim[] GetTokenClaims(string token);
}
