namespace Restaurant.Models;

public class Order
{
	public int Id { get; set; }
	public DateTime Created { get; set; }
	public virtual ICollection<OrderDish> OrderDishes { get; set; } = new List<OrderDish>();
	public int CustomerId { get; set; }
	public virtual Customer Customer { get; set; } = default!;
	public int OcupationId { get; set; }
	public virtual Ocupation Ocupation { get; set; } = default!;
}
