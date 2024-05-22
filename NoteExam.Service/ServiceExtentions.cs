using Microsoft.Extensions.DependencyInjection;
using NoteExam.Service.AuthServices;
using NoteExam.Service.NoteServices;

namespace NoteExam.Service;

public static class ServiceExtentions
{
	public static IServiceCollection AddServices(this IServiceCollection services)
	{
		// AuthServices
		services.AddScoped<IAuthService, AuthService>();
		services.AddScoped<ITokenService, TokenService>();
		services.AddScoped<IPasswordService, PasswordService>();

		// NoteServices
		services.AddScoped<INoteService, NoteService>();

		return services;
	}
}
