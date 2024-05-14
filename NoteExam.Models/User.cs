namespace NoteExam.Models;

public class User
{
	public Guid Id { get; set; }
	public string Username { get; set; } = string.Empty;
	public string PasswordHash { get; set; } = string.Empty;
	public string PasswordSalt { get; set; } = string.Empty;
	public string JwtToken { get; set; } = string.Empty;
	public string RefreshToken { get; set; } = string.Empty;
}
