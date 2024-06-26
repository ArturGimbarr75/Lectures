using _041_Les_Car_API.DTO;
using _041_Les_Car_API.Helpers;
using _041_Les_Car_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _041_Les_Car_API.Controllers;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class CarController : ControllerBase
{
	private readonly ICarService _carService;

	public CarController(ICarService carService)
	{
		_carService = carService;
	}

	[HttpGet("GetAllCars")]
	public IActionResult GetAllCars()
	{
		return Ok(_carService.GetAllCars());
	}

	[HttpGet("GetCarsByColor")]
	public IActionResult GetCarsByColor([FromQuery] string color)
	{
		return Ok(_carService.GetCarsByColor(color));
	}

	[Authorize(Roles = Roles.ADMIN)]
	[HttpPost("AddNewCar")]
	public IActionResult AddNewCar([FromBody] CarDto car)
	{
		var newCar = _carService.AddNewCar(car);
		return CreatedAtAction(nameof(GetAllCars), new { id = newCar.Id }, newCar);
	}

	[Authorize(Roles = Roles.ADMIN)]
	[HttpPut("UpdateCar")]
	public IActionResult UpdateCar([FromQuery] Guid id, [FromBody] CarDto car)
	{
		var updatedCar = _carService.UpdateCar(id, car);
		if (updatedCar is null)
		{
			return NotFound();
		}
		return Ok(updatedCar);
	}

	[Authorize(Roles = Roles.ADMIN)]
	[HttpDelete("{id}")]
	public IActionResult DeleteCar(Guid id)
	{
		var result = _carService.DeleteCar(id);
		if (result)
		{
			return NoContent();
		}
		return NotFound();
	}
}
