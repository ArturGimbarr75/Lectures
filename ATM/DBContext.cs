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
}