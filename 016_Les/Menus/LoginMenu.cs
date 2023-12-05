internal class LoginMenu : MenuWindowBase
{
	private AuthorizedMenu _authorizedMenu;

	private readonly Auth _auth;

	public LoginMenu(MenuWindowBase? parrent) : base(parrent)
	{
		_auth = new Auth();
		_authorizedMenu = new AuthorizedMenu(this);
	}

	public override MenuWindowBase? Show()
	{
		base.Show();

		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("Login");
		Console.ResetColor();

		Console.WriteLine("1. Login");
		Console.WriteLine("2. Back");

		int choice = Choose(2);
		switch (choice)
		{
			case 1:
				Console.Clear();
				AuthorizedUser.Instance = _auth.Login();
				Console.Clear();
				if (AuthorizedUser.Instance != null)
				{
					Console.WriteLine($"Welcome, {AuthorizedUser.Instance.Username}!");
					return _authorizedMenu;
				}

				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Login failed!");
				Console.ResetColor();
				Console.WriteLine("Press any key to continue...");
				Console.ReadKey();
				return this;

			case 2:
				return _parrent;

			default:
				Console.WriteLine("Invalid choice");
				return this;
		}
	}
}