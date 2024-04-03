using _041_Les_Car_API.DTO;
using _041_Les_Car_API.Models;

namespace _041_Les_Car_API.Services;

public interface ICarService
{
	IEnumerable<Car> GetAllCars();
	IEnumerable<Car> GetCarsByColor(string color);
	Car AddNewCar(CarDto car);
	Car UpdateCar(Guid id, CarDto car);
	bool DeleteCar(Guid id);
}
