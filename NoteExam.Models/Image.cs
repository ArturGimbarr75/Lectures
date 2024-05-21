namespace NoteExam.Models;

public class Image
{
    public Guid Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public string Path { get; set; } = string.Empty;
	public Guid UserId { get; set; }
	public virtual User User { get; set; } = default!;
}
