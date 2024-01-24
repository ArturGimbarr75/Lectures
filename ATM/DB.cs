using ATM.Models;
using System.Data.Entity;

namespace ATM;

internal class DB : IDB
{
	private readonly DBContext _context;

	public DB()
	{
		_context = new DBContext();
		_context.Database.EnsureCreated();
	}

	public bool AddAccount(Account account)
	{
		_context.Accounts.Add(account);
		return _context.SaveChanges() > 0;
	}

	public bool AddCard(Card card)
	{
		_context.Cards.Add(card);
		return _context.SaveChanges() > 0;
	}

	public bool AddTransaction(Transaction transaction)
	{
		_context.Transactions.Add(transaction);
		return _context.SaveChanges() > 0;
	}

	public Account? GetAccount(string name)
	{
		return _context.Accounts.Include(a => a.Cards).Include(a => a.Transactions).FirstOrDefault(a => a.Name == name);
	}

	public bool UpdateAccount(Account account)
	{
		_context.Accounts.Update(account);
		return _context.SaveChanges() > 0;
	}
}
