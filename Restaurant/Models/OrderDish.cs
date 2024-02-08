namespace Restaurant.Models;

public class OrderDish
{
	public int Id { get; set; }
	public int OrderId { get; set; }
	public virtual Order Order { get; set; } = default!;
	public int DishId { get; set; }
	public virtual Dish Dish { get; set; } = default!;
}
