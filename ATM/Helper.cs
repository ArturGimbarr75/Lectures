using ATM.Models;

namespace ATM;

public static class Helper
{
	public static int ReadSelection(int min, int max)
	{
		while (true)
		{
			string input = Console.ReadLine() ?? string.Empty;

			if (int.TryParse(input, out int selection))
			{
				if (selection >= min && selection <= max)
				{
					return selection;
				}
			}

			Console.WriteLine("Invalid selection.");
		}
	}

	public static bool CanExecuteTransaction(Account account)
	{
		DateTime todayUtc = DateTime.UtcNow.Date;
		return account.Transactions.Count(t => t.Date > todayUtc) < account.TransactionLimitPerDay;
	}

	public static Card? SelectCard(Account account)
	{
		Console.WriteLine("Select card: ");
		for (int i = 0; i < account.Cards.Count; i++)
			Console.WriteLine($"{i + 1}. {account.Cards[i].Number}");
		Console.WriteLine($"{account.Cards.Count + 1}. Cancel");
		int selection = Helper.ReadSelection(1, account.Cards.Count + 1);

		if (selection == account.Cards.Count + 1)
		{
			Console.WriteLine("Transaction cancelled");
			return null;
		}

		return account.Cards[selection - 1];
	}
}
