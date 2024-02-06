using Newtonsoft.Json;
using Restaurant.Models;

namespace Restaurant.DB;

internal class MockDatabase
{
	private List<Customer> _customers = new();
	private List<Dish> _dishes = new();
	private List<Order> _orders = new();
	private List<Ocupation> _ocupations = new();

    public MockDatabase()
    {
        string dishesJson = File.ReadAllText("Dishes.json");
		_dishes = JsonConvert.DeserializeObject<List<Dish>>(dishesJson)!;
    }
}
