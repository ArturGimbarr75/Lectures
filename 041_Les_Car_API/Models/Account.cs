namespace _041_Les_Car_API.Models;

public class Account
{
	public Guid Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public string Role { get; set; } = string.Empty;
	public string PasswordHash { get; set; } = string.Empty;
	public string PasswordSalt { get; set; } = string.Empty;
	public string? JwtToken { get; set; }
	public string? RefreshToken { get; set; }
}
