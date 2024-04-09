using _042_Les_External_API.Models;
using Microsoft.EntityFrameworkCore;

namespace _042_Les_External_API​.Repositories.EF;

public class AppDbContext : DbContext
{
	public DbSet<MeanTemperature> MeanTemperatures { get; set; }

	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
		Database.EnsureCreated();
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<MeanTemperature>().HasKey(mt => mt.Id);
	}
}

