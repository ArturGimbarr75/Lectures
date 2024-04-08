using _042_Les_External_API.Models;

namespace _042_Les_External_API​.Repositories
{
	public interface IWeatherRepository
	{
		void SaveWeatherInfo(Day weatherInfo);
	}
}
