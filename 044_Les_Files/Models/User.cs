namespace _044_Les_Files.Models;

public class User
{
	public Guid Id { get; set; }
	public string Name { get; set; } = default!;
	public string? ProfilePicturePath { get; set; }
}
