internal abstract class MenuWindowBase
{
	public MenuWindowBase? _parrent { get; protected set; }

    public MenuWindowBase(MenuWindowBase? parrent)
    {
        _parrent = parrent;
    }

    public virtual MenuWindowBase? Show()
	{
		Console.Clear();
		Console.ForegroundColor = ConsoleColor.Cyan;
		if (AuthorizedUser.Instance == null)
			Console.WriteLine("Unauthorized");
		else
			Console.WriteLine($"Authorized as {AuthorizedUser.Instance.Username}");
        Console.WriteLine();
		Console.ResetColor();

        return this;
	}

	protected int Choose(int count)
	{
		int result;
		Console.Write("Choice: ");
		string choice = Console.ReadLine() ?? "";
		while (!(int.TryParse(choice, out result) && result > 0 && result <= count))
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Invalid choice");
			Console.ResetColor();
			choice = Console.ReadLine() ?? "";
		}

		return result;
	}
}
