using Restaurant.Models;

namespace Restaurant.DB.Repositories;

internal interface IDishRepository
{
	IEnumerable<Dish> GetAll();
	Dish? Get(int id);
	IEnumerable<Dish> GetByType(FoodType type);
	Dish Add(Dish dish);
	Dish Update(Dish dish);
	bool Delete(int id);
}
