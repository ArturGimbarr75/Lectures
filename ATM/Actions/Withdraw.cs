using ATM.Models;

namespace ATM.Actions;

internal class Withdraw
{
	private readonly IDB _db;
	private readonly Account _account;

	public Withdraw(IDB db, Account account)
	{
		_db = db;
		_account = account;
	}

	public void Run()
	{
		if (!Helper.CanExecuteTransaction(_account))
		{
			Console.WriteLine("Transaction limit exceeded");
			return;
		}

		Card? card = Helper.SelectCard(_account);
		if (card is null)
		{
			Console.WriteLine("Transaction cancelled");
			return;
		}

        Console.WriteLine($"Current balance: {_account.Balance:0.00}");
		decimal amount = 0;
			
		while (true)
		{
            Console.Write("Enter amount to withdraw (enter 0 to cancel): ");
			if (!decimal.TryParse(Console.ReadLine() ?? string.Empty, out amount))
				Console.WriteLine("Invalid amount");
			else if (amount > _account.Balance)
				Console.WriteLine("Insufficient funds");
			else if (amount <= 0)
				Console.WriteLine("Invalid amount");
			else
				break;
		}

		if (amount == 0)
		{
            Console.WriteLine("Transaction cancelled");
            return;
		}

		Transaction transaction = new()
		{
			Id = Guid.NewGuid(),
			Amount = amount,
			Account = _account,
			Card = card,
			Date = DateTime.UtcNow,
			TransactionType = TransactionType.Withdraw,
			AccountId = _account.Id,
			CardId = card.Id
		};

		_account.Balance -= amount;
		_db.AddTransaction(transaction);
		Console.WriteLine($"New balance: {_account.Balance:0.00}");
	}
}
