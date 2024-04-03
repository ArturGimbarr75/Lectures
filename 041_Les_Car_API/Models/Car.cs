namespace _041_Les_Car_API.Models;

public class Car
{
	public Guid Id { get; set; } = Guid.NewGuid();
	public string Make { get; set; }
	public string Model { get; set; }
	public string Color { get; set; }
	public int Year { get; set; }
}
