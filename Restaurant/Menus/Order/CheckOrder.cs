using Restaurant.DB.Repositories;
using Restaurant.Models;

namespace Restaurant.Menus.Order;

internal class CheckOrder : MenuBase
{
	public override string Title => "Check Order";

	public CheckOrder(MenuBase? parent) : base(parent)
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

		Console.Clear();
		PrintPath();
		Console.WriteLine();

		var order = SelectOrder(customer);

		if (order is null)
		{
			Console.WriteLine("No orders found.");
			return;
		}

		Console.Clear();
		PrintPath();
		Console.WriteLine();

		PrintOrder(order, customer);
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

		var customers = customerRepository.GetAll().ToList();
		Models.Customer? customer = null;

		if (customers.Count == 0)
		{
			Console.WriteLine("No customers found.");
			return customer;
		}

		Console.WriteLine("Select a customer:");
		for (int i = 0; i < customers.Count; i++)
			Console.WriteLine($" {i + 1,3}) {customers[i].Name}");
		Console.WriteLine($" {customers.Count + 1,3}) Cancel");

		int input = GetInput(1, customers.Count + 1);

		if (input == customers.Count + 1)
			return customer;
		customer = customers[input - 1];

		return customer;
	}

	private Models.Order? SelectOrder(Models.Customer customer)
	{
		IOrderRepository orderRepository = GlobalVars.OrderRepository;

		var orders = orderRepository.GetAllByCustomerWithAllInfo(customer.Id).ToList();

		Models.Order? order = null;

		if (orders.Count == 0)
		{
			Console.WriteLine("No orders found.");
			return order;
		}

		Console.WriteLine("Select an order:");
		for (int i = 0; i < orders.Count; i++)
			Console.WriteLine($" {i + 1, 3}) {orders[i].Ocupation.Start} - {orders[i].Ocupation.End}");
		Console.WriteLine($" {orders.Count + 1, 3}) Cancel");

		int index = GetInput(1, orders.Count + 1);

		if (index != orders.Count + 1)
			order = orders[index - 1];

		return order;
	}

	private void PrintOrder(Models.Order order, Models.Customer customer)
	{
		IOrderRepository orderRepository = GlobalVars.OrderRepository;

		var dishes = orderRepository.GetOrderDishes(order.Id).ToList();

		Console.WriteLine();

		Console.ForegroundColor = ConsoleColor.Magenta;
		Console.Write("Order: ");
		Console.ResetColor();
		Console.WriteLine(order.Id);

		Console.ForegroundColor = ConsoleColor.DarkGreen;
		Console.Write($"Start: ");
		Console.ResetColor();
		Console.WriteLine($"{order.Ocupation.Start}");

		Console.ForegroundColor = ConsoleColor.DarkGreen;
		Console.Write($"End: ");
		Console.ResetColor();
		Console.WriteLine($"{order.Ocupation.End}");

		Console.ForegroundColor = ConsoleColor.DarkGreen;
		Console.Write($"Table: ");
		Console.ResetColor();
		Console.WriteLine($"{order.Ocupation.Table}");

		Console.ForegroundColor = ConsoleColor.DarkGreen;
		Console.Write($"Customer: ");
		Console.ResetColor();
		Console.WriteLine(customer.Name);

		Console.ForegroundColor = ConsoleColor.DarkGreen;
		Console.WriteLine("Dishes:");
		foreach (var dish in order.OrderDishes)
		{
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.Write($" - ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write($"{dish.Dish.Name}");
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.WriteLine($" ({dish.Dish.Price}$)");
		}

		Console.ForegroundColor = ConsoleColor.Green;
		Console.Write($"Total: $");
		Console.ForegroundColor = ConsoleColor.DarkGreen;
		Console.WriteLine($"{order.OrderDishes.Sum(d => d.Dish.Price)}$");
		Console.ResetColor();
	}
}
