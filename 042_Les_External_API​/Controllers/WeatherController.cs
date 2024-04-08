using _042_Les_External_API.Repositories;
using _042_Les_External_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace _042_Les_External_API​.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherController : ControllerBase
	{
		private readonly IWeatherService _weatherService;
		private readonly IWeatherRepository _weatherRepository;

		public WeatherController(IWeatherService weatherService, IWeatherRepository weatherRepository)
		{
			_weatherService = weatherService;
			_weatherRepository = weatherRepository;
		}

		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] string city)
		{
			var weatherInfo = await _weatherService.GetWeatherAsync(city);
			if (weatherInfo is null)
				return NotFound();

			_weatherRepository.SaveWeatherInfo(weatherInfo);
			return Ok(weatherInfo);
		}
	}
}
