using _041_Les_Car_API.Controllers;
using _041_Les_Car_API.DTO;
using _041_Les_Car_API.Models;
using _041_Les_Car_API.Services;
using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace _043_Les_Car_API_Tests;

public class CarControllerTests
{
	private readonly Mock<ICarService> _mockCarService;
	private readonly CarController _carController;
	private readonly Fixture _fixture;

	public CarControllerTests()
	{
		_mockCarService = new Mock<ICarService>();
		_carController = new CarController(_mockCarService.Object);
		_fixture = new Fixture();
	}

	[Fact]
	public void GetAllCars_ShouldReturnAllCars()
	{
		// Arrange
		var fakeCars = _fixture.CreateMany<Car>().ToList();
		_mockCarService.Setup(service => service.GetAllCars()).Returns(fakeCars);

		// Act
		var result = _carController.GetAllCars();

		// Assert
		var okResult = Assert.IsType<OkObjectResult>(result);
		var returnedCars = Assert.IsType<List<Car>>(okResult.Value);
		Assert.Equal(fakeCars.Count, returnedCars.Count);
	}

	[Theory]
	[InlineData("red")]
	[InlineData("blue")]
	public void GetCarsByColor_ShouldReturnCarsByColor(string color)
	{
		// Arrange
		var fakeCars = _fixture.Build<Car>().With(car => car.Color, color).CreateMany().ToList();
		_mockCarService.Setup(service => service.GetCarsByColor(color)).Returns(fakeCars);

		// Act
		var result = _carController.GetCarsByColor(color);

		// Assert
		var okResult = Assert.IsType<OkObjectResult>(result);
		var returnedCars = Assert.IsType<List<Car>>(okResult.Value);
		Assert.All(returnedCars, car => Assert.Equal(color, car.Color));
	}

	[Fact]
	public void AddNewCar_ShouldCreateCar()
	{
		// Arrange
		var fakeCarDto = _fixture.Create<CarDto>();
		var fakeCar = _fixture.Create<Car>();
		_mockCarService.Setup(service => service.AddNewCar(fakeCarDto)).Returns(fakeCar);

		// Act
		var result = _carController.AddNewCar(fakeCarDto);

		// Assert
		var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
		Assert.Equal(nameof(_carController.GetAllCars), createdAtActionResult.ActionName);
		Assert.Equal(fakeCar.Id, createdAtActionResult.RouteValues["id"]);
	}

	[Fact]
	public void UpdateCar_ShouldUpdateCar_WhenCarExists()
	{
		// Arrange
		var carId = Guid.NewGuid();
		var fakeCarDto = _fixture.Create<CarDto>();
		var fakeCar = _fixture.Create<Car>();
		_mockCarService.Setup(service => service.UpdateCar(carId, fakeCarDto)).Returns(fakeCar);

		// Act
		var result = _carController.UpdateCar(carId, fakeCarDto);

		// Assert
		var okResult = Assert.IsType<OkObjectResult>(result);
		Assert.Equal(fakeCar, okResult.Value);
	}

	[Fact]
	public void UpdateCar_ShouldReturnNotFound_WhenCarDoesNotExist()
	{
		// Arrange
		var carId = Guid.NewGuid();
		var fakeCarDto = _fixture.Create<CarDto>();
		_mockCarService.Setup(service => service.UpdateCar(carId, fakeCarDto)).Returns((Car)null!);

		// Act
		var result = _carController.UpdateCar(carId, fakeCarDto);

		// Assert
		Assert.IsType<NotFoundResult>(result);
	}
}