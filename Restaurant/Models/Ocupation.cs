namespace Restaurant.Models;

public class Ocupation
{
	public int Id { get; set; }
	public DateTime Start { get; set; }
	public DateTime? End { get; set; }
	public int Table { get; set; }
	public virtual Customer Customer { get; set; } = default!;
}
