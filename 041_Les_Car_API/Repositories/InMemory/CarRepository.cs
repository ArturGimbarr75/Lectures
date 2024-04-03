using _041_Les_Car_API.Models;

namespace _041_Les_Car_API.Repositories.InMemory;

public class CarRepository : ICarRepository
{
    private readonly List<Car> _cars = new();

    public IEnumerable<Car> GetAllCars()
        => _cars;

    public IEnumerable<Car> GetCarsByColor(string color)
        => _cars.Where(c => c.Color.Equals(color, StringComparison.OrdinalIgnoreCase));

    public Car AddNewCar(Car car)
    {
        _cars.Add(car);
        return car;
    }

    public Car UpdateCar(Guid id, Car car)
    {
        var existingCar = _cars.FirstOrDefault(c => c.Id == id);
        if (existingCar is not null)
        {
            existingCar.Make = car.Make;
            existingCar.Model = car.Model;
            existingCar.Color = car.Color;
            existingCar.Year = car.Year;
        }
        return existingCar;
    }

    public bool DeleteCar(Guid id)
    {
        var car = _cars.FirstOrDefault(c => c.Id == id);
        return car != null && _cars.Remove(car);
    }
}
