namespace _036_V2_Les.Models;

public class File
{
	public int Id { get; set; }
	public string Name { get; set; } = default!;
	public string Path { get; set; } = default!;
	public string Extension { get; set; } = default!;
	public long Size { get; set; }
	
	public int MainFolderId { get; set; } = default!;
	public virtual MainFolder Folder { get; set; } = default!;
	public virtual ICollection<Tag> Tags { get; set; } = default!;
}