using _039_Les_API.Models;
using Microsoft.EntityFrameworkCore;

namespace _039_Les_API.DB;

public class AppDbContext : DbContext
{
    public DbSet<Person> People { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
		Database.EnsureCreated();
    }
}
