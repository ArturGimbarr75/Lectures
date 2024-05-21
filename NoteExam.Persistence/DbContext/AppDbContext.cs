using Microsoft.EntityFrameworkCore;
using NoteExam.Models;

namespace NoteExam.Persistence.Context;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Note> Notes { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Image> Images { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		modelBuilder.Entity<User>()
			.HasMany(u => u.Categories)
			.WithOne(c => c.User)
			.HasForeignKey(c => c.UserId)
			.OnDelete(DeleteBehavior.NoAction);

		modelBuilder.Entity<User>()
			.HasMany(u => u.Notes)
			.WithOne(n => n.User)
			.HasForeignKey(n => n.UserId)
			.OnDelete(DeleteBehavior.NoAction);

		modelBuilder.Entity<User>()
			.HasMany(u => u.Images)
			.WithOne(i => i.User)
			.HasForeignKey(i => i.UserId)
			.OnDelete(DeleteBehavior.NoAction);

		modelBuilder.Entity<Category>()
			.HasMany(c => c.Notes)
			.WithOne(n => n.Category)
			.HasForeignKey(n => n.CategoryId)
			.OnDelete(DeleteBehavior.Cascade);

		base.OnModelCreating(modelBuilder);
	}
}
