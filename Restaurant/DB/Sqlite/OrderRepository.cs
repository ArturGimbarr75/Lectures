using Microsoft.EntityFrameworkCore;
using Restaurant.DB.Repositories;
using Restaurant.Models;

namespace Restaurant.DB.Sqlite;

internal class OrderRepository : IOrderRepository
{
	private readonly DBContext _dbContext;

	public OrderRepository(DBContext context)
	{
		_dbContext = context;
	}

	public Order Add(Order order)
	{
		_dbContext.Orders.Add(order);
		_dbContext.SaveChanges();
		return order;
	}

	public void AddDishesRange(IEnumerable<Dish> dishes, Order order)
	{
        Order? order1 = _dbContext.Orders.Find(order.Id);

		if (order1 is null)
			return;

		foreach (var dish in dishes)
			order1.OrderDishes.Add(new OrderDish { DishId = dish.Id, OrderId = order1.Id });
		_dbContext.SaveChanges();
	}

	public IEnumerable<Order> GetAllByCustomerWithAllInfo(int customerId)
	{
		return _dbContext.Orders
				.Where(o => o.Ocupation.Customer.Id == customerId)
				.Include(o => o.Ocupation)
				.AsEnumerable();
	}

	public Order? GetOrderByCustomer(int customerId)
	{
		return _dbContext.Orders
			.FirstOrDefault(o => o.Ocupation.Customer.Id == customerId && o.Ocupation.End == null);
	}

	public IEnumerable<OrderDish> GetOrderDishes(int orderId)
	{
		return _dbContext.OrderDishes
			.Where(od => od.OrderId == orderId)
			.Include(od => od.Dish)
			.AsEnumerable();
	}
}
