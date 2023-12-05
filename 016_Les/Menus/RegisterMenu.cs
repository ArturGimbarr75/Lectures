internal class RegisterMenu : MenuWindowBase
{
	private readonly Auth _auth;

	public RegisterMenu(MenuWindowBase? parrent) : base(parrent)
	{
		_auth = new Auth();
	}

	public override MenuWindowBase? Show()
	{
		base.Show();

		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("Register");
		Console.ResetColor();

		Console.WriteLine("1. Register");
		Console.WriteLine("2. Back");

		int choice = Choose(2);
		switch (choice)
		{	
			case 1:
				Console.Clear();
				_auth.Register();
				Console.WriteLine("Press any key to continue...");
				Console.ReadKey();
				return this;
		
			case 2:
				Console.Clear();
				return _parrent;
		
			default:
				Console.WriteLine("Invalid choice");
				return this;
		}
	}
}