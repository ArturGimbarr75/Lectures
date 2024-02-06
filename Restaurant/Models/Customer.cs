namespace Restaurant.Models;

public class Customer
{
	public int Id { get; set; }
	public string Name { get; set; } = default!;
	public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
	public virtual ICollection<Ocupation> Ocupations { get; set; } = new List<Ocupation>();
}
