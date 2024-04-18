namespace _041_Les_Car_API.Models;

public class Account
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public string PasswordHash { get; set; }
	public string PasswordSalt { get; set; }
	public string? JwtToken { get; set; }
	public string? RefreshToken { get; set; }
}
