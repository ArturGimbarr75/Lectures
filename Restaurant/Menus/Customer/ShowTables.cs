using Restaurant.DB.Repositories;
using Restaurant.Models;

namespace Restaurant.Menus.Customer;

internal class ShowTables : MenuBase
{
	public override string Title => "Show Tables";

    public ShowTables(MenuBase? parrent) : base(parrent)
    {
		
	}

	public override void Display(int startPoint = 1, bool drawBack = true)
	{
		Console.Clear();
		PrintPath();
		Console.WriteLine();

		ICustomerRepository customerRepo = GlobalVars.CustomerRepository;
		List<Models.Customer> customers = customerRepo.GetAllSitingAtTables().ToList();

		Show(customers);
	}

	private void Show(List<Models.Customer> customers)
	{
		Console.ForegroundColor = ConsoleColor.Cyan;
		Console.WriteLine(" Tables:");
		Console.ForegroundColor = ConsoleColor.Blue;

		for (int i = 0; i < GlobalVars.MAX_TABLE_COUNT; i++)
		{
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write($" {i + 1,3}) ");

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

	public override MenuBase? HandleInput(int startPoint = 1, int endPoint = 1)
	{
		Console.WriteLine(" Press any key to continue...");
		Console.ReadKey(true);
		return _parentMenu;
	}
}
