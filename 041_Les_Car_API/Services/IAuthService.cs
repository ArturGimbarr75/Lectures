using _041_Les_Car_API.Models;
using _041_Les_Car_API.Repositories.EF;

namespace _041_Les_Car_API.Services;

public interface IAuthService
{
	Task<Account> SignUp(string name, string password);
	Task<(string jwt, string refresh)> LogIn(string name, string password);
}
