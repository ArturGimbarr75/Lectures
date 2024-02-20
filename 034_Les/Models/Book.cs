using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Book
{
	public Guid Id { get; set; }
	public string Title { get; set; } = default!;
	public string? Description { get; set; }
	public string Content { get; set; } = default!;

	[ForeignKey("Author")]
	public Guid AuthorId { get; set; }
	public virtual Author Author { get; set; } = default!;
}
