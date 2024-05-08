using _044_Les_Files.Models;
using Microsoft.EntityFrameworkCore;

namespace _044_Les_Files.Repositories;

public class AppDbContext : DbContext
{
	public DbSet<User> Users { get; set; } = default!;

	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{

	}
}
