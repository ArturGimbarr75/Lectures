using _042_Les_External_API.Models;
using Newtonsoft.Json;

namespace _042_Les_External_API​.Services
{
	public class WeatherService : IWeatherService
	{
		private readonly HttpClient _httpClient;
		private readonly string _apiKey;

		public WeatherService(HttpClient httpClient, IConfiguration configuration)
		{
			_httpClient = httpClient;
			_apiKey = configuration["ApiKey"]!;
		}

		public async Task<Day?> GetWeatherAsync(string city)
		{
			var url = $"https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/{city}?unitGroup=us&key={_apiKey}&contentType=json";
			var response = await _httpClient.GetAsync(url);
			response.EnsureSuccessStatusCode();

			var content = await response.Content.ReadAsStringAsync();
			var weatherInfo = JsonConvert.DeserializeObject<WeatherInfo>(content);

			Day? today = weatherInfo?.days[0];

			return today;
		}
	}
}
