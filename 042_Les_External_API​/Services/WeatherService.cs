using _042_Les_External_API.Models;
using _042_Les_External_API.Repositories;
using Newtonsoft.Json;

namespace _042_Les_External_API​.Services
{
	public class WeatherService : IWeatherService
	{
		private readonly IWeatherRepository _weatherRepository;
		private readonly HttpClient _httpClient;
		private readonly string _apiKey;

		public WeatherService(HttpClient httpClient, IConfiguration configuration, IWeatherRepository weatherRepository)
		{
			_httpClient = httpClient;
			_apiKey = configuration["ApiKey"]!;
			_weatherRepository = weatherRepository;
		}

		public async Task<MeanTemperature?> GetMeanTemperatureAsync(string city)
		{
			string date = DateTime.Now.ToString("yyyy-MM-dd");
			if (await _weatherRepository.Has(city, date))
			{
				return await _weatherRepository.Get(city, date);
			}

			var url = $"https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/{city}?unitGroup=us&key={_apiKey}&contentType=json";
			var response = await _httpClient.GetAsync(url);
			response.EnsureSuccessStatusCode();

			var content = await response.Content.ReadAsStringAsync();
			var weatherInfo = JsonConvert.DeserializeObject<WeatherInfo>(content);

			if ((weatherInfo?.days?.Count ?? 0) == 0)
			{
				return null;
			}

			MeanTemperature meanTemperature = new()
			{
				Date = weatherInfo.days.First().datetime,
				City = weatherInfo.address,
				Temperature = weatherInfo.days.Sum(d => d.temp) / weatherInfo.days.Count
			};

			await _weatherRepository.Add(meanTemperature);

			return meanTemperature;
		}
	}
}
