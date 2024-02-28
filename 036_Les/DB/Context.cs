using _036_Les.Models;
using Microsoft.EntityFrameworkCore;

namespace _036_Les.DB;

internal class Context : DbContext
{
    public DbSet<MainFolder> MainFolders { get; set; }
    public DbSet<Models.File> Files { get; set; }
    public DbSet<Tag> Tags { get; set; }

    public Context()
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
			.HasForeignKey(f => f.MainFolderId);

        modelBuilder.Entity<Models.File>()
            .HasMany(f => f.Tags)
			.WithMany(t => t.Files);
	}
}
