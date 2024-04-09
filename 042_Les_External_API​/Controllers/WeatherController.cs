using _042_Les_External_API.Repositories;
using _042_Les_External_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace _042_Les_External_API​.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class WeatherController : ControllerBase
	{
		private readonly IWeatherService _weatherService;
		private readonly IWeatherRepository _weatherRepository;

		public WeatherController(IWeatherService weatherService, IWeatherRepository weatherRepository)
		{
			_weatherService = weatherService;
			_weatherRepository = weatherRepository;
		}

		[HttpGet(Name = "GetMeanTemperature")]
		public async Task<IActionResult> GetMeanTemperature(string city)
		{
			var meanTemperature = await _weatherService.GetMeanTemperatureAsync(city);
			if (meanTemperature is null)
			{
				return NotFound();
			}

			return Ok(meanTemperature);
		}

		[HttpGet(Name = "GetMeanTemperatures")]
		public async Task<IActionResult> GetMeanTemperatures(string city)
		{
			var meanTemperatures = await _weatherRepository.GetByCity(city);
			if (meanTemperatures is null)
			{
				return NotFound();
			}

			return Ok(meanTemperatures);
		}
		
	}
}
