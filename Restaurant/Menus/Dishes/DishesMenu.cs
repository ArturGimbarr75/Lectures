using Restaurant.DB.Repositories;
using Restaurant.Models;

namespace Restaurant.Menus.Dishes;

internal class DishesMenu : MenuBase
{
	public override string Title => "Dishes List";

	public DishesMenu(MenuBase? parrent) : base(parrent)
	{

	}

	public override void Display(int startPoint = 1, bool drawBack = true)
	{
		Console.Clear();
		PrintPath();
		Console.WriteLine();

		ShowDishes();
	}

	public override MenuBase? HandleInput(int startPoint = 1, int endPoint = 1)
	{
		Console.WriteLine(" Press any key to continue...");
		Console.ReadKey(true);
		return _parentMenu;
	}

	private void ShowDishes()
	{
		IDishRepository dishRepository = GlobalVars.DishRepository;

		foreach (FoodType type in Enum.GetValues<FoodType>())
		{
			var dishes = dishRepository.GetByType(type).ToList();

			if (dishes.Count == 0)
				continue;

			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine($" {type}:");
			for (int i = 0; i < dishes.Count; i++)
			{
				Console.ForegroundColor = ConsoleColor.White;
				Console.Write($" {i + 1, 3}) ");

				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.Write($"{dishes[i]!.Name,-30}");
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine($"{dishes[i]!.Price, 5:0.00}$");
			}
		}

		Console.ResetColor();
	}
}
