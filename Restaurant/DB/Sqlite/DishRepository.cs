using Restaurant.DB.Repositories;
using Restaurant.Models;

namespace Restaurant.DB.Sqlite;

internal class DishRepository : IDishRepository
{
	private readonly DBContext _dbContext;

	public DishRepository(DBContext dbContext)
	{
		_dbContext = dbContext;
	}

	public Dish Add(Dish dish)
	{
		_dbContext.Dishes.Add(dish);
		_dbContext.SaveChanges();
		return dish;
	}

	public bool Delete(int id)
	{
		var dish = _dbContext.Dishes.Find(id);

		if (dish is null)
			return false;

		_dbContext.Dishes.Remove(dish);
		_dbContext.SaveChanges();
		return true;
	}

	public Dish? Get(int id)
	{
		return _dbContext.Dishes.Find(id);
	}

	public IEnumerable<Dish> GetAll()
	{
		return _dbContext.Dishes.AsEnumerable();
	}

	public IEnumerable<Dish> GetByType(FoodType type)
	{
		return _dbContext.Dishes.Where(d => d.FoodType == type).AsEnumerable();
	}

	public Dish Update(Dish dish)
	{
		var existingDish = _dbContext.Dishes.Find(dish.Id);

		if (existingDish is null)
			return dish;

		existingDish.Name = dish.Name;
		existingDish.Price = dish.Price;
		existingDish.FoodType = dish.FoodType;
		_dbContext.SaveChanges();

		return existingDish;
	}
}
