namespace _044_Les_Files_V2.Models;

public class Image
{
	public int Id { get; set; }
	public string Filename { get; set; } = default!;
	public byte[] Data { get; set; } = default!;
}
