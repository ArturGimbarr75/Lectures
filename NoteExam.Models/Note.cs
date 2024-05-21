namespace NoteExam.Models;

public class Note
{
	public Guid Id { get; set; }
	public string Title { get; set; } = string.Empty;
	public string Content { get; set; } = string.Empty;
	public DateTime CreatedAt { get; set; }
	public DateTime UpdatedAt { get; set; }
	public Guid CategoryId { get; set; }
	public virtual Category Category { get; set; } = default!;
	public Guid UserId { get; set; }
	public virtual User User { get; set; } = default!;
}
