using Microsoft.Extensions.DependencyInjection;
using NoteExam.Service.Auth;

namespace NoteExam.Service;

public static class ServiceExtentions
{
	public static IServiceCollection AddServices(this IServiceCollection services)
	{
		services.AddScoped<IAuthService, AuthService>();
		services.AddScoped<ITokenService, TokenService>();
		services.AddScoped<IPasswordService, PasswordService>();

		return services;
	}
}
