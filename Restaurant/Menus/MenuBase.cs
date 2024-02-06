namespace Restaurant.Menus;

internal abstract class MenuBase
{
    public virtual string Title { get; } = "Menu";

    public virtual int StartPoint { get; } = 1;
    public virtual int EndPoint { get => _subMenus.Count + 1; }
        
	protected MenuBase? _parentMenu;
	protected List<MenuBase> _subMenus = new();

    public MenuBase(MenuBase? parrent)
    {
        _parentMenu = parrent;
    }

    protected void PrintPath()
    {
		if (_parentMenu is not null)
        {
			_parentMenu.PrintPath();
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.Write(" > ");
		}

		Console.ForegroundColor = ConsoleColor.Green;
		Console.Write(Title);
		Console.ResetColor();
	}

    public virtual void Display(int startPoint = 1, bool drawBack = true)
    {
		Console.Clear();   
        PrintPath();
        Console.WriteLine();

        for (int i = 0; i < _subMenus.Count; i++)
            Console.WriteLine($" {startPoint + i}) {_subMenus[i].Title}");

        if (drawBack && _parentMenu != null)
            Console.WriteLine($" {startPoint + _subMenus.Count}) Back");
        else if (drawBack)
			Console.WriteLine($" {startPoint + _subMenus.Count}) Exit");
	}

    protected int GetInput(int min, int max)
    {
		string input;
		int result;

		do
		{
			Console.Write(" > ");
			input = Console.ReadLine()!;
		} while (!int.TryParse(input, out result) || result < min || result > max);

        return result;
	}

    public virtual MenuBase? HandleInput(int min, int max)
    {
        int choice = GetInput(min, max);

		return choice == max ? _parentMenu : _subMenus[choice - min];
	}
}
