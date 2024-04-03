using _041_Les_Car_API.Models;

namespace _041_Les_Car_API.Repositories;

public interface ICarRepository
{
	IEnumerable<Car> GetAllCars();
	IEnumerable<Car> GetCarsByColor(string color);
	Car AddNewCar(Car car);
	Car UpdateCar(Guid id, Car car);
	bool DeleteCar(Guid id);
}
