using _041_Les_Car_API.Models;
using Microsoft.EntityFrameworkCore;

namespace _041_Les_Car_API.Repositories.EF;

public class AddDbContext : DbContext
{
	public DbSet<Car> Cars { get; set; }

	public AddDbContext(DbContextOptions<AddDbContext> options) : base(options)
	{
		Database.EnsureCreated();
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Car>().HasData(
			new Car
			{
				Id = Guid.NewGuid(),
				Make = "Toyota",
				Model = "Corolla",
				Year = 2020,
				Color = "Red"
			},
			new Car
			{
				Id = Guid.NewGuid(),
				Make = "Ford",
				Model = "Fusion",
				Year = 2019,
				Color = "Blue"
			},
			new Car
			{
				Id = Guid.NewGuid(),
				Make = "Honda",
				Model = "Civic",
				Year = 2018,
				Color = "Green"
			});
	}
}
