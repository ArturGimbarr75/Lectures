namespace Restaurant.Menus;

internal class MainMenu : MenuBase
{
	public override string Title => "Main Menu";
	public override int EndPoint => _subMenus.Count + 1;

	public MainMenu(MenuBase? parrent) : base(parrent)
	{
		_subMenus.Add(new Customer.CustomerMenu(this));
		_subMenus.Add(new Dishes.DishesMenu(this));
	}
}
