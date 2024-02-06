namespace Restaurant.Models;

public class Order
{
	public int Id { get; set; }
	public DateTime Created { get; set; }
	public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
	public virtual Customer Customer { get; set; } = default!;
}
