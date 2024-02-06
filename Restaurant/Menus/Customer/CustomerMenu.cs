namespace Restaurant.Menus.Customer;

internal class CustomerMenu : MenuBase
{
    public override string Title => "Customer Menu";

    public CustomerMenu(MenuBase? parrent) : base(parrent)
    {
        _subMenus.Add(new AddCustomer(this));
        _subMenus.Add(new EndOcupation(this));
        _subMenus.Add(new ShowTables(this));
    }
}
