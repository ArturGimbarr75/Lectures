using ATM.Models;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace ATM.Actions;

internal class AddCard
{
	private readonly MockDB _db;
	private readonly Account _account;

	public AddCard(MockDB db, Account account)
	{
		_db = db;
		_account = account;
	}

	public void Run()
	{
		string pin = string.Empty;
		Regex regex = new(@"^\d{4}$");
        Console.Write("Enter PIN (4 digits): ");
		pin = Console.ReadLine() ?? string.Empty;
		while (!regex.IsMatch(pin))
		{
			Console.Write("Enter PIN (4 digits): ");
			pin = Console.ReadLine() ?? string.Empty;
		}

		string pinHash = String.Empty;
		using (SHA256 sha256 = SHA256.Create())
		{
			byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pin));
			pinHash = BitConverter.ToString(bytes).Replace("-", "").ToLower();
		}

		Card card = new()
		{
			Id = Guid.NewGuid(),
			Account = _account,
			Number = Guid.NewGuid().ToString("N")[..16],
			PinHash = pinHash,
			AccountId = _account.Id
		};

		_db.AddCard(card);
	}
}
