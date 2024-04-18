using _041_Les_Car_API.Models;

namespace _041_Les_Car_API.Services;

public interface IJWTService
{
	string GenerateSecurityToken(Account account);
	string GenerateRefreshToken(Account account);
}
