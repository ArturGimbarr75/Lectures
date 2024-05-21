namespace NoteExam.Models;

public class User
{
	public Guid Id { get; set; }
	public string Username { get; set; } = string.Empty;
	public string PasswordHash { get; set; } = string.Empty;
	public string PasswordSalt { get; set; } = string.Empty;
	public string? JwtToken { get; set; } = string.Empty;
	public string? RefreshToken { get; set; } = string.Empty;
	public virtual ICollection<Category> Categories { get; set; } = default!;
	public virtual ICollection<Note> Notes { get; set; } = default!;
	public virtual ICollection<Image> Images { get; set; } = default!;
}
