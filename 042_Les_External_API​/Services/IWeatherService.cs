using _042_Les_External_API.Models;

namespace _042_Les_External_API​.Services
{
	public interface IWeatherService
	{
		Task<MeanTemperature?> GetMeanTemperatureAsync(string city);
	}
}
