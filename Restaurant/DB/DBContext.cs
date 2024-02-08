using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant.DB;

internal class DBContext : DbContext
{
	public DbSet<Customer> Customers { get; set; }
	public DbSet<Dish> Dishes { get; set; }
	public DbSet<Order> Orders { get; set; }
	public DbSet<Ocupation> Ocupations { get; set; }
	public DbSet<OrderDish> OrderDishes { get; set; }

    public DBContext()
	{
		Database.EnsureCreated();
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite("Data Source=restaurant.db");
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Customer>()
			.HasMany(c => c.Ocupations)
			.WithOne(o => o.Customer)
			.HasForeignKey(o => o.CustomerId);

		modelBuilder.Entity<Customer>()
			.HasMany(c => c.Orders)
			.WithOne(o => o.Customer)
			.HasForeignKey(o => o.CustomerId);

		modelBuilder.Entity<Ocupation>()
			.HasOne(o => o.Customer)
			.WithMany(c => c.Ocupations);

		modelBuilder.Entity<Order>()
			.HasOne(o => o.Customer)
			.WithMany(c => c.Orders);
	}
}
