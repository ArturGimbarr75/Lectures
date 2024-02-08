using Restaurant.DB.Repositories;
using Restaurant.Models;

namespace Restaurant.Menus.Order;

internal class AddOrder : MenuBase
{
	public override string Title => "Add order";

	public AddOrder(MenuBase? parent) : base(parent)
	{
	}

	public override void Display(int startPoint = 1, bool drawBack = true)
	{
		Console.Clear();
		PrintPath();
		Console.WriteLine();

		var customer = SelectCustomer();

		if (customer is null)
		{
            Console.WriteLine("No customers found.");
			return;
        }

		SelectDishes(customer);
	}

	public override MenuBase? HandleInput(int min, int max)
	{
        Console.WriteLine("Press any key to continue...");
		Console.ReadKey();
        return _parentMenu;
	}

	private Models.Customer? SelectCustomer()
	{
		ICustomerRepository customerRepository = GlobalVars.CustomerRepository;

		var customers = customerRepository.GetAllSitingAtTables().ToList();
		Models.Customer? customer = null;

		if (customers.Count == 0)
		{
			Console.WriteLine("No customers found.");
			return customer;
		}

		Console.WriteLine("Select a customer:");
		for (int i = 0; i < customers.Count; i++)
			Console.WriteLine($" {i + 1, 3}) {customers[i].Name}");
        Console.WriteLine($" {customers.Count + 1, 3}) Cancel");

		int input = GetInput(1, customers.Count + 1);

		if (input == customers.Count + 1)
			return customer;
		customer = customers[input - 1];

		return customer;
    }

	private void SelectDishes(Models.Customer customer)
	{
		IDishRepository dishRepository = GlobalVars.DishRepository;
		IOrderRepository orderRepository = GlobalVars.OrderRepository;

		var dishes = dishRepository.GetAll().ToList();
		var selectedDishes = new List<Models.Dish>();

		if (dishes.Count == 0)
		{
			Console.WriteLine("No dishes found.");
			return;
		}

		Console.WriteLine("Select a dish:");
		for (int i = 0; i < dishes.Count; i++)
			Console.WriteLine($" {i + 1, 3}) {dishes[i].Name}");
		Console.WriteLine($" {dishes.Count + 1, 3}) Done");

		int input;
		do
		{
			input = GetInput(1, dishes.Count + 1);
			if (input == dishes.Count + 1)
				break;
			selectedDishes.Add(dishes[input - 1]);
            Console.WriteLine($"Added {dishes[input - 1].Name} to the order.");
        } while (true);

		Models.Order? order = orderRepository.GetOrderByCustomer(customer.Id);
		if (order is null)
		{
			Ocupation ocupation = customer.Ocupations.First(o => o.End == null);
			order = new Models.Order
			{
				OcupationId = ocupation.Id,
				Ocupation = ocupation,
				CustomerId = customer.Id,
				Customer = customer
			};
			order = orderRepository.Add(order);
		}

		orderRepository.AddDishesRange(selectedDishes, order);
        Console.WriteLine("Order complete.");
	}
}
