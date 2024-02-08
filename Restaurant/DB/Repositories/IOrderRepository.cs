using Restaurant.Models;

namespace Restaurant.DB.Repositories;

internal interface IOrderRepository
{
	Order Add(Order order);
	void AddDishesRange(IEnumerable<Dish> dishes, Order order);
	Order? GetOrderByCustomer(int customerId);
	IEnumerable<Order> GetAllByCustomerWithAllInfo(int customerId);
	IEnumerable<OrderDish> GetOrderDishes(int orderId);
}
