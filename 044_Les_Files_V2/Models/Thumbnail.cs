namespace _044_Les_Files_V2.Models;

public class Thumbnail
{
	public int Id { get; set; }
	public int ImageId { get; set; }
	public byte[] Data { get; set; } = default!;
	public Image Image { get; set; } = default!;
}
