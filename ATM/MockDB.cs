using ATM.Models;
using Newtonsoft.Json;
namespace ATM;

internal class MockDB : IDB
{
	private List<Account> Accounts { get; set; }

	private const string FILENAME = "accounts.json";

    public MockDB()
    {
		if (File.Exists(FILENAME))
			LoadFromFile();

		Accounts ??= new();
    }

	public Account? GetAccount(string name)
	{
		return Accounts.FirstOrDefault(a => a.Name.Equals(name));
	}

	public bool AddAccount(Account account)
	{
		if (GetAccount(account.Name) is not null)
			return false;

		Accounts.Add(account);
		SaveToFile();
		return true;
	}

	public bool UpdateAccount(Account account)
	{
		Account? existing = GetAccount(account.Name);

		if (existing is null)
			return false;

		existing.Balance = account.Balance;
		SaveToFile();
		return true;
	}

	public bool AddCard(Card card)
	{
		Account? existing = GetAccount(card.Account.Name);
		if (existing is null)
			return false;

		existing.Cards.Add(card);
		SaveToFile();
		return true;
	}

	public bool AddTransaction(Transaction transaction)
	{
		Account? existing = GetAccount(transaction.Account.Name);
		if (existing is null)
			return false;

		existing.Transactions.Add(transaction);
		SaveToFile();
		return true;
	}

    private void SaveToFile()
	{
		List<Account> copy = new();
		foreach (Account account in Accounts)
		{
			Account copyAccount = new()
			{
				Name = account.Name,
				PasswordHash = account.PasswordHash,
				Balance = account.Balance,
				Cards = new(),
				Transactions = new(),
				TransactionLimitPerDay = account.TransactionLimitPerDay,
				Id = account.Id
			};

			foreach (Card card in account.Cards)
			{
				Card copyCard = new()
				{
					Id = card.Id,
					Number = card.Number,
					PinHash = card.PinHash,
					AccountId = copyAccount.Id
				};

				copyAccount.Cards.Add(copyCard);
			}

			foreach (Transaction transaction in account.Transactions)
			{
				Transaction copyTransaction = new()
				{
					Id = transaction.Id,
					Amount = transaction.Amount,
					Date = transaction.Date,
					AccountId = copyAccount.Id,
					CardId = transaction.Card.Id,
					TransactionType = transaction.TransactionType
				};

				copyAccount.Transactions.Add(copyTransaction);
			}

			copy.Add(copyAccount);
		}

		string json = JsonConvert.SerializeObject(copy, Formatting.Indented);
		File.WriteAllText(FILENAME, json);
	}

	private void LoadFromFile()
	{
		string json = File.ReadAllText(FILENAME);
		Accounts = JsonConvert.DeserializeObject<List<Account>>(json)!;

		foreach (Account account in Accounts)
		{
			foreach (Card card in account.Cards)
			{
				card.Account = account;
			}

			foreach (Transaction transaction in account.Transactions)
			{
				transaction.Account = account;
				transaction.Card = account.Cards.First(c => c.Id.Equals(transaction.CardId));
			}
		}
	}
}
