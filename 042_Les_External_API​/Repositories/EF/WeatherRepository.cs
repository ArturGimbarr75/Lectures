using _042_Les_External_API.Models;
using Microsoft.EntityFrameworkCore;

namespace _042_Les_External_API​.Repositories.EF
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly AppDbContext _context;

        public WeatherRepository(AppDbContext context)
        {
			_context = context;
		}

        public async Task Add(MeanTemperature meanTemperature)
        {
			await _context.MeanTemperatures.AddAsync(meanTemperature);
			await _context.SaveChangesAsync();
		}

        public async Task<IEnumerable<MeanTemperature?>> GetByCity(string city)
        {
            return await Task.FromResult(_context.MeanTemperatures.Where(mt => mt.City == city).AsEnumerable());
        }

        public async Task<bool> Has(string city, string date)
        {
			return await _context.MeanTemperatures.AnyAsync(mt => mt.City == city && mt.Date == date);
		}

        public async Task<MeanTemperature?> Get(string city, string date)
        {
            return await _context.MeanTemperatures.FirstOrDefaultAsync(mt => mt.City == city && mt.Date == date);
        }
    }
}
