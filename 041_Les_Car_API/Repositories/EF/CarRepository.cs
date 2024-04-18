using _041_Les_Car_API.Models;

namespace _041_Les_Car_API.Repositories.EF;

public class CarRepository : ICarRepository
{
	private readonly AppDbContext _context;

	public CarRepository(AppDbContext context)
	{
		_context = context;
	}

	public Car AddNewCar(Car car)
	{
		_context.Cars.Add(car);
		_context.SaveChanges();
		return car;
	}

	public bool DeleteCar(Guid id)
	{
		var car = _context.Cars.Find(id);
		if (car == null)
		{
			return false;
		}

		_context.Cars.Remove(car);
		_context.SaveChanges();
		return true;
	}

	public IEnumerable<Car> GetAllCars()
	{
		return _context.Cars;
	}

	public IEnumerable<Car> GetCarsByColor(string color)
	{
		return _context.Cars.Where(c => c.Color == color);
	}

	public Car UpdateCar(Guid id, Car car)
	{
		var existingCar = _context.Cars.Find(id);
		if (existingCar == null)
		{
			return null;
		}

		existingCar.Make = car.Make;
		existingCar.Model = car.Model;
		existingCar.Year = car.Year;
		existingCar.Color = car.Color;

		_context.SaveChanges();
		return existingCar;
	}
}
