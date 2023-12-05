internal class AuthorizedMenu : MenuWindowBase
{
	private MainMenu _mainMenu = default!;

	private Hangman _hangman;

	public AuthorizedMenu(MenuWindowBase? parrent) : base(parrent)
	{
		MenuWindowBase? current = parrent;
		while (current != null)
		{
			if (current is MainMenu mainMenu)
			{
				_mainMenu = mainMenu;
				break;
			}

			current = current._parrent;
		}

		_hangman = new Hangman();
	}

	public override MenuWindowBase? Show()
	{
		base.Show();
		Console.WriteLine("1. Play Hangman");
		Console.WriteLine("2. Play TicTacToe");
		Console.WriteLine("3. Statistics");
		Console.WriteLine("4. Logout");

		switch (Choose(2))
		{
			case 1:
				Console.Clear();
				_hangman.Play();
                Console.WriteLine("Press any key to continue...");
				Console.ReadKey();
                return this;

			case 2:
				Console.Clear();
				//new TicTacToe().Play();
				Console.WriteLine("Press any key to continue...");
				Console.ReadKey();
				return this;

			case 3:
				Console.Clear();
				Console.WriteLine("Statistics");
				Console.WriteLine("Press any key to continue...");
				Console.ReadKey();
				return this;

			case 4:
				AuthorizedUser.Instance = null;
				return _mainMenu;

			default:
				return this;
		}
	}
}
