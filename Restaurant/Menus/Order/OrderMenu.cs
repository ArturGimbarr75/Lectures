namespace Restaurant.Menus.Order;

internal class OrderMenu : MenuBase
{
	public override string Title => "Order Menu";
	public override int EndPoint => _subMenus.Count + 1;

	public OrderMenu(MenuBase? parrent) : base(parrent)
	{
		_subMenus.Add(new AddOrder(this));
		_subMenus.Add(new CheckOrder(this));
	}

	public override void Display(int startPoint = 1, bool drawBack = true)
	{
		Console.Clear();
		PrintPath();
		Console.WriteLine();

		base.Display(startPoint, drawBack);
	}
}
