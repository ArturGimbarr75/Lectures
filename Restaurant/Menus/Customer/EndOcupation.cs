using Restaurant.DB.Repositories;

namespace Restaurant.Menus.Customer;

internal class EndOcupation : MenuBase
{
	public override string Title => "End Ocupation";

	public EndOcupation(MenuBase? parrent) : base(parrent)
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

		if (customers.Count == 0)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(" No customers are sitting at tables!");
			Console.ResetColor();
		}
		else
		{
			EndOcupationAtTable(customers);
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
				Console.WriteLine($"{customer.Name,-20} {customer.Ocupations.Max(o => o.Start)}");
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

	private void EndOcupationAtTable(List<Models.Customer> customers)
	{
		Console.Write(" Enter table number: ");
		int table = GetInput(1, GlobalVars.MAX_TABLE_COUNT);
		while (customers.All(c => c.Ocupations.Any(o => o.Table == table)))
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(" No customer at that table!");
			Console.ResetColor();
			Console.Write(" Enter table number: ");
			table = GetInput(1, GlobalVars.MAX_TABLE_COUNT);
		}
			
		Models.Customer? customer = customers.FirstOrDefault(c => c.Ocupations.Any(o => o.Table == table && o.End == null));
		if (customer is null)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(" No customer at that table!");
			Console.ResetColor();
			return;
		}

		IOcupationRepository ocupationRepo = GlobalVars.OcupationRepository;
		Models.Ocupation? ocupation = ocupationRepo.GetLastByCustomer(customer.Id);
		if (ocupation is null)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(" Customer is not sitting at that table!");
			Console.ResetColor();
			return;
		}

		ocupation.End = DateTime.Now;
		ocupationRepo.Update(ocupation);
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine($"{customer.Name} has left the table {table}.");
		Console.ResetColor();
	}
}
