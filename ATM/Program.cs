using ATM;
using ATM.Actions;
using ATM.Models;

IDB db;
//db = new MockDB();
db = new DB();
Account? account = null;

Registration registration = new(db);
Login login = new(db);

while (true)
{
	if (account is null)
	{
        Console.WriteLine("1. Register");
		Console.WriteLine("2. Login");
		Console.WriteLine("3. Exit");

		int selection = Helper.ReadSelection(1, 3);
		Console.Clear();

		switch (selection)
		{
			case 1:
				registration.Run();
				break;
			case 2:
				account = login.Run();
				break;
			case 3:
				return;
		}
    }
	else
	{
        Console.WriteLine($"User: {account.Name}");
		Console.WriteLine($"Balance: {account.Balance:0.00}");
        Console.WriteLine();
        Console.WriteLine("1. Add card");
		Console.WriteLine("2. Show all cards");
		Console.WriteLine("3. Transactions");
		Console.WriteLine("4. Withdraw");
		Console.WriteLine("5. Deposit");
		Console.WriteLine("6. Logout");
		Console.WriteLine("7. Exit");

		int selection = Helper.ReadSelection(1, 7);
		Console.Clear();

		switch (selection)
		{
			case 1:
				AddCard addCard = new(db, account);
				addCard.Run();
				break;

			case 2:
				Console.WriteLine("Cards: ");
				Console.WriteLine("#======================================+==================#");
				Console.WriteLine("| Guid                                 | Number           |");
				Console.WriteLine("#======================================+==================#");
				foreach (Card card in account.Cards)
					Console.WriteLine($"|{card.Id, 37} |{card.Number, 17} |");
				Console.WriteLine("#======================================+==================#");

				break;

			case 3:
                Console.WriteLine("Transactions: ");
				Console.WriteLine("#=================+=======================+==================#================#");
				Console.WriteLine("| Amount          | Date                  | Card             | Type           |");
				Console.WriteLine("#=================+=======================+==================#================#");
				foreach (Transaction transaction in account.Transactions)
                    Console.WriteLine($"|{transaction.Amount, 16} |{transaction.Date, 22} |{transaction.Card.Number, 17} |{transaction.TransactionType, 15} |");
				Console.WriteLine("#=================+=======================+==================#================#");

                break;

			case 4:
				Withdraw withdraw = new(db, account);
				withdraw.Run();
				break;

			case 5:
				Deposit deposit = new(db, account);
				deposit.Run();
				break;

			case 6:
				account = null;
				break;

			case 7:
				return;
		}
    }

	Console.WriteLine("Press any key to continue...");
	Console.ReadKey(true);
	Console.Clear();
}
