namespace NoteExam.DTO;

public class NoteDto
{
	public string Title { get; set; } = string.Empty;
	public string Content { get; set; } = string.Empty;
	public Guid? CategoryId { get; set; } = null;
}
