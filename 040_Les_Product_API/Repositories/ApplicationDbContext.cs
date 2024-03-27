using _040_Les_Product_API.Models;
using Microsoft.EntityFrameworkCore;

namespace _040_Les_Product_API.Repositories;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
