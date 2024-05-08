using _044_Les_Files_V2.Models;
using Microsoft.EntityFrameworkCore;

namespace _044_Les_Files_V2.Repositories;

public class ApplicationDbContext : DbContext
{
	public DbSet<Image> Images { get; set; }
	public DbSet<Thumbnail> Thumbnails { get; set; }

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{

	}
}
