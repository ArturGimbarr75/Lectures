using _042_Les_External_API.Models;

namespace _042_Les_External_API​.Repositories.EF
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly List<Day> _weatherData = new();

        public void SaveWeatherInfo(Day day)
        {
            _weatherData.Add(day);
        }
    }
}
