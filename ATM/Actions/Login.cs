using ATM.Models;
using System.Security.Cryptography;
using System.Text;

namespace ATM.Actions;

internal class Login
{
	private readonly IDB _db;

	public Login(IDB db)
	{
		_db = db;
	}

	public Account? Run()
	{
		Console.WriteLine("Enter your name:");
		string name = Console.ReadLine() ?? string.Empty;

		Console.WriteLine("Enter your password:");
		string password = Console.ReadLine() ?? string.Empty;

		Account? existing = _db.GetAccount(name);

		if (existing is null)
		{
			Console.WriteLine("Account does not exist.");
			return null;
		}

		string passwordHash = string.Empty;
		using (SHA256 sha256 = SHA256.Create())
		{
			byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
			passwordHash = BitConverter.ToString(bytes).Replace("-", "").ToLower();
		}

		if (!existing.PasswordHash.Equals(passwordHash))
		{
			Console.WriteLine("Incorrect password.");
			return null;
		}

		return existing;
	}
}
