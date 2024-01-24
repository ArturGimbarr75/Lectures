using ATM.Models;
using Microsoft.EntityFrameworkCore;

namespace ATM;

public class DBContext : DbContext
{
	public DbSet<Account> Accounts { get; set; }
	public DbSet<Card> Cards { get; set; }
	public DbSet<Transaction> Transactions { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite("Data Source=accounts.db");
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Account>()
			.HasMany(a => a.Cards)
			.WithOne(c => c.Account)
			.HasForeignKey(c => c.AccountId);

		modelBuilder.Entity<Account>()
			.HasMany(a => a.Transactions)
			.WithOne(t => t.Account)
			.HasForeignKey(t => t.AccountId);

		modelBuilder.Entity<Transaction>()
			.HasOne(t => t.Card)
			.WithMany(c => c.Transactions)
			.HasForeignKey(t => t.CardId);

		modelBuilder.Entity<Card>()
			.HasOne(c => c.Account)
			.WithMany(a => a.Cards)
			.HasForeignKey(c => c.AccountId);

		modelBuilder.Entity<Card>()
			.HasMany(c  => c.Transactions)
			.WithOne(t => t.Card)
			.HasForeignKey(t => t.CardId);
	}
}