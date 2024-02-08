using Restaurant.DB;
using Restaurant.DB.Repositories;

namespace Restaurant;

internal static class GlobalVars
{
	public const int MAX_TABLE_COUNT = 10;

	public static DBContext DBContext { get; set; } = default!;

	public static ICustomerRepository CustomerRepository { get; set; } = default!;
	public static IOcupationRepository OcupationRepository { get; set; } = default!;
	public static IDishRepository DishRepository { get; set; } = default!;
	public static IOrderRepository OrderRepository { get; set; } = default!;
}
