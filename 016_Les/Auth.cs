using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

internal class Auth
{
	private static readonly MockUserTable _userTable = new();

	public User? Login()
	{
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("Login");
		Console.ResetColor();

		Console.WriteLine("Name:");
		string name = Console.ReadLine()!;

		Console.WriteLine("Password:");
		string password = ReadPassword();

		User? user = _userTable.GetUser(name);
		if (user == null)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("User does not exist!");
			Console.ResetColor();
			return null;
		}

		string hashedPassword = HashPassword(password, user.Salt);
		if (hashedPassword != user.Password)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Invalid password!");
			Console.ResetColor();
			return null;
		}

		return user;
	}

	public void Register()
	{
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("Registration");
		Console.ResetColor();

		Regex usernameRegex = new Regex(@"^[a-zA-Z0-9]{3,15}$");
		Console.WriteLine("Name (3-15 characters, only letters and numbers):");
		string name;
		do
		{
			name = Console.ReadLine()!;
			if (!usernameRegex.IsMatch(name))
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Invalid username!");
				Console.ResetColor();
			}
		}
		while (!usernameRegex.IsMatch(name));

		Regex passwordRegex = new Regex(@"^[a-zA-Z0-9!@#$%^&*()_+]{8,20}$");
		Console.WriteLine("Password (8-20 characters, only letters, numbers and special characters):");
		string password;

		do
		{
			password = ReadPassword();
			if (!passwordRegex.IsMatch(password))
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("\nInvalid password!");
				Console.ResetColor();
			}
			else
			{
				break;
			}
		}
		while (true);
        Console.WriteLine();

        Console.WriteLine("\nRepeat password: ");
		string repeatedPassword = string.Empty;
		for (int tries = 0; tries < 5; tries++)
		{
			repeatedPassword = ReadPassword();
			if (password != repeatedPassword)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("\nPasswords do not match!");
				Console.ResetColor();
			}
			else
			{
				break;
			}
		}

		if (password != repeatedPassword)
		{
			Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Registraition failed");
            Console.ResetColor();
			return;
		}

		string salt = GenerateSalt();
		string hashedPassword = HashPassword(password, salt);

		User user = new ()
		{
			Username = name,
			Password = hashedPassword,
			Salt = salt
		};

		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("\nRegistraition successful!");
		Console.ResetColor();

		_userTable.AddUser(user);
	}

	private string ReadPassword()
	{
		string password = string.Empty;

		do
		{
			ConsoleKeyInfo key = Console.ReadKey(true);
			if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
			{
				password += key.KeyChar;
				Console.Write("*");
			}
			else
			{
				if (key.Key == ConsoleKey.Backspace && password.Length > 0)
				{
					password = password[0..^1];
					Console.Write("\b \b");
				}
				else if (key.Key == ConsoleKey.Enter)
				{
					break;
				}
			}
		}
		while (true);

		return password;
	}

	private string GenerateSalt()
	{
		byte[] salt = new byte[32];
		using RandomNumberGenerator rng = RandomNumberGenerator.Create();
		rng.GetBytes(salt);

		return Convert.ToBase64String(salt);
	}

	private string HashPassword(string password, string salt)
	{
		using SHA256 sha256Hash = SHA256.Create();
		byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password + salt));

		return Convert.ToBase64String(bytes);
	}
}
