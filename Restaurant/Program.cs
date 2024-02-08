using Restaurant;
using Restaurant.DB;
using Restaurant.DB.Sqlite;
using Restaurant.Menus;

GlobalVars.DBContext = new DBContext();

GlobalVars.CustomerRepository = new CustomerRepository(GlobalVars.DBContext);
GlobalVars.OcupationRepository = new OcupationRepository(GlobalVars.DBContext);
GlobalVars.DishRepository = new DishRepository(GlobalVars.DBContext);
GlobalVars.OrderRepository = new OrderRepository(GlobalVars.DBContext);

MenuBase? currentMenu = new MainMenu(null);
// FillDishes();

while (currentMenu is not null)
{
	currentMenu.Display();
	currentMenu = currentMenu.HandleInput(currentMenu.StartPoint, currentMenu.EndPoint);
}

void FillDishes()
{
	string json = File.ReadAllText("Dishes.json");
	List<Restaurant.Models.Dish> dishes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Restaurant.Models.Dish>>(json)!;

	foreach (var dish in dishes)
		GlobalVars.DishRepository.Add(dish);
}
