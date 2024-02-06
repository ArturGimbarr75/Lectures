using Restaurant;
using Restaurant.DB;
using Restaurant.DB.Sqlite;
using Restaurant.Menus;

GlobalVars.DBContext = new DBContext();

GlobalVars.CustomerRepository = new CustomerRepository(GlobalVars.DBContext);
GlobalVars.OcupationRepository = new OcupationRepository(GlobalVars.DBContext);
GlobalVars.DishRepository = new DishRepository(GlobalVars.DBContext);

MenuBase? currentMenu = new MainMenu(null);

while (currentMenu is not null)
{
	currentMenu.Display();
	currentMenu = currentMenu.HandleInput(currentMenu.StartPoint, currentMenu.EndPoint);
}