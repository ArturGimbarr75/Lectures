namespace _041_Les_Car_API.Services;

public interface IPasswordHasher
{
	void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt);
	bool VerifyPasswordHash(string password, string storedHash, string storedSalt);
}
