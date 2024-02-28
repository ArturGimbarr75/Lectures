using _036_V2_Les.Models;
using Microsoft.EntityFrameworkCore;

namespace _036_Les.DB;

public class AppDbContext : DbContext
{
    public DbSet<MainFolder> MainFolders { get; set; }
    public DbSet<_036_V2_Les.Models.File> Files { get; set; }
    public DbSet<Tag> Tags { get; set; }

    public AppDbContext()
    {
        Database.EnsureCreated();
	}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseSqlite("Data Source=Folder.db");
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Folder;Trusted_Connection=True;");
	}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		modelBuilder.Entity<MainFolder>()
            .HasMany(mf => mf.InnerFiles)
			.WithOne(f => f.Folder)
			.HasForeignKey(f => f.MainFolderId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<_036_V2_Les.Models.File>()
            .HasMany(f => f.Tags)
			.WithMany(t => t.Files);
	}
}
