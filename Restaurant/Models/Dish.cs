namespace Restaurant.Models;

public class Dish
{
	public int Id { get; set; }
	public string Name { get; set; } = default!;
	public string? Description { get; set; } = default!;
	public decimal Price { get; set; }
	public FoodType FoodType { get; set; }
	public virtual ICollection<Order> Orders { get; set; } = default!;
}
