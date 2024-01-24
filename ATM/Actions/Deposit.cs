using ATM.Models;

namespace ATM.Actions;

internal class Deposit
{
	private readonly IDB _db;
	private readonly Account _account;

	public Deposit(IDB db, Account account)
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

		decimal amount = 0;

		while (true)
		{
			Console.WriteLine("Enter amount to deposit (enter 0 to cancel): ");
			decimal.TryParse(Console.ReadLine() ?? string.Empty, out amount);

			if (amount < 0)
				Console.WriteLine("Invalid amount");
			else
				break;
		}

		if (amount == 0)
		{
			Console.WriteLine("Transaction cancelled");
			return;
		}

		Card? card = Helper.SelectCard(_account);
		if (card is null)
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
			TransactionType = TransactionType.Deposit,
			AccountId = _account.Id,
			CardId = card.Id
		};

		_account.Balance += amount;
		_db.AddTransaction(transaction);

		Console.WriteLine($"New balance: {_account.Balance:0.00}");
	}
}
