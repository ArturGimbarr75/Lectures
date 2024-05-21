namespace NoteExam.Models;

public class Category
{
	public Guid Id { get; set; }
	public string Name { get; set; } = default!;
	public string Description { get; set; } = default!;
	public Guid UserId { get; set; }
	public virtual User User { get; set; } = default!;
	public virtual ICollection<Note> Notes { get; set; } = default!;
}
