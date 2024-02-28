namespace _036_Les.Models;

public class Tag
{
	public int Id { get; set; }
	public string Name { get; set; } = default!;

	public virtual ICollection<File> Files { get; set; } = default!;
}
