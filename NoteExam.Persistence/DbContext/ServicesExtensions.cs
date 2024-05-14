using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace NoteExam.Persistence.Context;

public static class ServicesExtensions
{
	public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
	{
		services.AddDbContext<AppDbContext>(options =>
		{
			options.UseSqlServer(connectionString);
		});

		return services;
	}
}
