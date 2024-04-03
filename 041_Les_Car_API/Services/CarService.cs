using _041_Les_Car_API.DTO;
using _041_Les_Car_API.Models;
using _041_Les_Car_API.Repositories;

namespace _041_Les_Car_API.Services;

public class CarService : ICarService
{
	private readonly ICarRepository _carRepository;

	public CarService(ICarRepository carRepository)
	{
		_carRepository = carRepository;
	}

	public IEnumerable<Car> GetAllCars()
	{
		return _carRepository.GetAllCars();
	}

	public IEnumerable<Car> GetCarsByColor(string color)
	{
		return _carRepository.GetCarsByColor(color);
	}

	public Car AddNewCar(CarDto car)
	{
		var newCar = new Car
		{
			Make = car.Make,
			Model = car.Model,
			Color = car.Color,
			Year = car.Year
		};
		return _carRepository.AddNewCar(newCar);
	}

	public Car UpdateCar(Guid id, CarDto car)
	{
		var existingCar = _carRepository.GetAllCars().FirstOrDefault(c => c.Id == id);
		if (existingCar == null)
		{
			return null;
		}

		existingCar.Make = car.Make;
		existingCar.Model = car.Model;
		existingCar.Color = car.Color;
		existingCar.Year = car.Year;

		return _carRepository.UpdateCar(id, existingCar);
	}

	public bool DeleteCar(Guid id)
	{
		return _carRepository.DeleteCar(id);
	}
}