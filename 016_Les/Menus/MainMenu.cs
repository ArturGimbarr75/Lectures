internal class MainMenu : MenuWindowBase
{
	private LoginMenu _loginMenu;
	private RegisterMenu _registerMenu;

	public MainMenu() : base(null)
	{
		_loginMenu = new LoginMenu(this);
		_registerMenu = new RegisterMenu(this);
	}

	public override MenuWindowBase? Show()
	{
		base.Show();

		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("Main menu");
		Console.ResetColor();

		Console.WriteLine("1. Login");
		Console.WriteLine("2. Register");
		Console.WriteLine("3. Exit");

		int choice = Choose(3);
		switch (choice)
		{
			case 1:
				Console.Clear();
				return _loginMenu;

			case 2:
				Console.Clear();
				return _registerMenu;

			case 3:
				Console.Clear();
				Console.WriteLine("Bye!");
				return null;

			default:
				Console.WriteLine("Invalid choice");
				return this;
		}

	}
}
