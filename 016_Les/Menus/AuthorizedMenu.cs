internal class AuthorizedMenu : MenuWindowBase
{
	private MainMenu _mainMenu = default!;
	private StatisticsMenu _statisticsMenu = default!;

	private Hangman _hangman;
	private TikTakToe _tikTakToe;
	private Snake _snake;

	public AuthorizedMenu(MenuWindowBase? parrent) : base(parrent)
	{
		_statisticsMenu = new StatisticsMenu(this);
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
		_tikTakToe = new TikTakToe();
		_snake = new Snake();
	}

	public override MenuWindowBase? Show()
	{
		base.Show();
		Console.WriteLine("1. Play Hangman");
		Console.WriteLine("2. Play TicTacToe");
		Console.WriteLine("3. Play Snake");
		Console.WriteLine("4. Statistics");
		Console.WriteLine("5. Logout");

		int choice = Choose(5);
		switch (choice)
		{
			case 1:
				Console.Clear();
				_hangman.Play();
                Console.WriteLine("Press any key to continue...");
				Console.ReadKey();
                return this;

			case 2:
				Console.Clear();
				_tikTakToe.Play();
				Console.WriteLine("Press any key to continue...");
				Console.ReadKey();
				return this;

			case 3:
				Console.Clear();
				_snake.Play();
				Console.WriteLine("Press any key to continue...");
				Console.ReadKey();
				return this;

			case 4:
				return _statisticsMenu;

			case 5:
				AuthorizedUser.Instance = null;
				return _mainMenu;

			default:
				return this;
		}
	}
}
