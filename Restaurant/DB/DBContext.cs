using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant.DB;

internal class DBContext : DbContext
{
	public DbSet<Customer> Customers { get; set; }
	public DbSet<Dish> Dishes { get; set; }
	public DbSet<Order> Orders { get; set; }
	public DbSet<Ocupation> Ocupations { get; set; }

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
			.WithOne(o => o.Customer);

		modelBuilder.Entity<Customer>()
			.HasMany(c => c.Orders)
			.WithOne(o => o.Customer);

		modelBuilder.Entity<Dish>()
			.HasMany(d => d.Orders)
			.WithMany(o => o.Dishes);

		modelBuilder.Entity<Ocupation>()
			.HasOne(o => o.Customer)
			.WithMany(c => c.Ocupations);

		modelBuilder.Entity<Order>()
			.HasOne(o => o.Customer)
			.WithMany(c => c.Orders);

		modelBuilder.Entity<Order>()
			.HasMany(o => o.Dishes)
			.WithMany(d => d.Orders);
	}
}
