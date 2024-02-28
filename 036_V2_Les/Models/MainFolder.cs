namespace _036_V2_Les.Models;

public class MainFolder
{
	public int Id { get; set; }
	public string Name { get; set; } = default!;
	public string Path { get; set; } = default!;

	public virtual ICollection<File> InnerFiles { get; set; } = default!;
}
