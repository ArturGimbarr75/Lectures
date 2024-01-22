using ATM.Models;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace ATM.Actions;

internal class Registration
{
	private readonly MockDB _db;

	public Registration(MockDB db)
	{
		_db = db;
	}

	public void Run()
	{
		Console.WriteLine("Enter your name:");
		string name = Console.ReadLine() ?? string.Empty;

		Regex regex = new (@"^[a-zA-Z0-9]{4,16}$");
		Console.WriteLine("Enter your password:");
		string password;
		while (true)
		{
			password = Console.ReadLine() ?? string.Empty;

			if (regex.IsMatch(password))
				break;

			Console.WriteLine("Password must be 4-16 characters and contain only letters and numbers.");
		}
		
		string passwordHash = string.Empty;
		using (SHA256 sha256 = SHA256.Create())
		{
			byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
			passwordHash = BitConverter.ToString(bytes).Replace("-", "").ToLower();
		}

		Account? existing = _db.GetAccount(name);

		if (existing is not null)
		{
			Console.WriteLine("Account already exists.");
			return;
		}

		decimal balance = 0;
		Console.WriteLine("Enter your starting balance:");
		while (true)
		{
			string input = Console.ReadLine() ?? string.Empty;

			if (decimal.TryParse(input, out balance))
				break;

			Console.WriteLine("Invalid balance.");
		}

		Account account = new()
		{
			Name = name,
			PasswordHash = passwordHash,
			Id = Guid.NewGuid(),
			Balance = balance,
			Cards = new(),
			Transactions = new(),
			TransactionLimitPerDay = 10
		};

		_db.AddAccount(account);
		Console.WriteLine("Account created.");
	}
}
