using Microsoft.EntityFrameworkCore;
using Models;

public class Context : DbContext
{
	public DbSet<Author> Authors { get; set; }
	public DbSet<Book> Books { get; set; }

	public Context()
	{
		Database.EnsureCreated();
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer(@"Server=(localDB)\MSSQLLocalDB;Database=Books;Trusted_Connection=True;");
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Author>()
			.HasMany(a => a.Books)
			.WithOne(b => b.Author)
			.HasForeignKey(b => b.AuthorId);
	}
}