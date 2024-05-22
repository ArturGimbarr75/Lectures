using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NoteExam.Persistence.Repositories;
using NoteExam.Persistence.Repositories.EF;

namespace NoteExam.Persistence.Context;

public static class PersistenceExtensions
{
	public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
	{
		services.AddDbContext<AppDbContext>(options =>
		{
			options.UseSqlServer(connectionString);
		});

		services.AddScoped<IUserRepository, UserRepository>();
		services.AddScoped<INoteRepository, NoteRepository>();
		services.AddScoped<IImageRepository, ImageRepository>();
		services.AddScoped<ICategoryRepository, CategoryRepository>();

		return services;
	}
}
