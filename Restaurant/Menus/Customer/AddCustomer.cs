using Restaurant.DB.Repositories;
using Restaurant.Models;

namespace Restaurant.Menus.Customer;

internal class AddCustomer : MenuBase
{
	public override string Title => "Add Customer";

	public AddCustomer(MenuBase? parrent) : base(parrent)
	{

	}

	public override void Display(int startPoint = 1, bool drawBack = true)
	{
		Console.Clear();
		PrintPath();
		Console.WriteLine();

		ICustomerRepository customerRepo = GlobalVars.CustomerRepository;
		List<Models.Customer> customers = customerRepo.GetAllSitingAtTables().ToList();

		ShowTables(customers);
		Console.WriteLine();

		if (customers.Count == GlobalVars.MAX_TABLE_COUNT)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(" All tables are occupied!");
			Console.ResetColor();
		}
		else
		{
			AddCustomerToTable(customers);
		}		
	}

	public override MenuBase? HandleInput(int startPoint = 1, int endPoint = 1)
	{
		Console.WriteLine(" Press any key to continue...");
		Console.ReadKey(true);
		return _parentMenu;
	}

	private void ShowTables(List<Models.Customer> customers)
	{
		Console.ForegroundColor = ConsoleColor.Cyan;
		Console.WriteLine(" Tables:");
		Console.ForegroundColor = ConsoleColor.Blue;

		for (int i = 0; i < GlobalVars.MAX_TABLE_COUNT; i++)
		{
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write($" {i + 1, 3}) ");
			
			Models.Customer? customer = customers.FirstOrDefault(c => c.Ocupations.Any(o => o.Table == i + 1 && o.End == null));
			if (customer is not null)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine($"{customer.Name, -20} {customer.Ocupations.Max(o => o.Start)}");
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine("Empty");
			}

			Console.ResetColor();
		}

		Console.ResetColor();
	}

	private void AddCustomerToTable(List<Models.Customer> customers)
	{
		ICustomerRepository customerRepo = GlobalVars.CustomerRepository;
		IOcupationRepository ocupationRepo = GlobalVars.OcupationRepository;

		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine(" Select a table to add a customer to:");
		Console.ResetColor();

		int table;
		HashSet<int> ocupiedTables = customers.SelectMany(c => c.Ocupations)
											  .Where(c => c.End == null)
											  .Select(o => o.Table)
											  .ToHashSet();

		do
		{
			table = GetInput(1, GlobalVars.MAX_TABLE_COUNT);
		}
		while (ocupiedTables.Contains(table));

		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine(" Enter customer name:");
		Console.ResetColor();
		string name = Console.ReadLine()!;

		Models.Customer? customer = customerRepo.Get(name);

		if (customer is null)
		{
			customer = new Models.Customer { Name = name };
			customer = customerRepo.Add(customer);
		}

		Ocupation ocupation = new()
		{
			Start = DateTime.UtcNow,
			Table = table,
			Customer = customer	
		};

		ocupationRepo.Add(ocupation);	
	}
}
