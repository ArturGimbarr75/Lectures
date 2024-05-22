using NoteExam.Models;
using System.Security.Claims;

namespace NoteExam.Service.AuthServices;

public interface ITokenService
{
	string GenerateJwt(User user);
	string GenerateRefreshToken(User user);
	(Guid? id, DateTime? exp) GetTokenIdAndExpirationDate(string token);
	Claim[] GetTokenClaims(string token);
	bool IsTokenValid(string token);
}
