using _042_Les_External_API.Models;

namespace _042_Les_External_API​.Repositories
{
	public interface IWeatherRepository
	{
		public Task Add(MeanTemperature meanTemperature);
		public Task<IEnumerable<MeanTemperature?>> GetByCity(string city);
		public Task<bool> Has(string city, string date);
		public Task<MeanTemperature?> Get(string city, string date);
	}
}
