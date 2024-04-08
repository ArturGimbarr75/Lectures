using _042_Les_External_API.Models;

namespace _042_Les_External_API​.Services
{
	public interface IWeatherService
	{
		Task<Day?> GetWeatherAsync(string city);
	}
}
