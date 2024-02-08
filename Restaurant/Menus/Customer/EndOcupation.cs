using Restaurant.DB.Repositories;
using Restaurant.Models;

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

		for (int i = 0; i < customers.Count; i++)
		{
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write($" {i + 1, 3}) ");
			
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine($"{customers[i].Name,-20} {customers[i].Ocupations.Max(o => o.Start)}");

			Console.ResetColor();
		}
        Console.WriteLine($" {customers.Count + 1, 3}) Back");

        Console.ResetColor();
	}

	private void EndOcupationAtTable(List<Models.Customer> customers)
	{
		Console.Write(" Enter customer: ");
		int number = GetInput(1, customers.Count + 1);
		if (number == customers.Count + 1)
			return;

		Models.Customer customer = customers[number - 1];

		Models.Ocupation? ocupation = customer.Ocupations.FirstOrDefault(o => o.End == null);
		if (ocupation is null)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(" Customer is not sitting at that table!");
			Console.ResetColor();
			return;
		}

		IOcupationRepository ocupationRepo = GlobalVars.OcupationRepository;
		ocupation.End = DateTime.Now;
		ocupationRepo.Update(ocupation);
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine($"{customer.Name} has left the table {ocupation.Table}.");
		Console.ResetColor();
	}
}
