using Marketplace.Shared.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Marketplace.Shared.Authentication;

internal class AuthenticationConfigurator : IHostApplicationBuilderConfigurator, IWebApplicationConfigurator
{
	public void Configure(IHostApplicationBuilder builder)
	{
		AddAuthentication(builder);
		builder.Services.AddAuthorization();
	}

	public void Configure(WebApplication app)
	{
		app.UseAuthentication();
		app.UseAuthorization();
	}

	private static void AddAuthentication(IHostApplicationBuilder builder)
	{
		var settings = builder.Configuration.GetSection(nameof(AuthenticationSettings)).Get<AuthenticationSettings>();
		if (settings is null)
		{
			return;
		}

		var authenticationBuilder = builder.Services.AddAuthentication();
		if (settings.Cookie is not null)
		{
			authenticationBuilder.AddCookie(AuthenticationSchemeNames.Cookie, SetupCookieOptions(settings.Cookie));
		}
	}

	private static Action<CookieAuthenticationOptions> SetupCookieOptions(CookieSettings cookieSettings)
	{
		return options =>
		{
			options.Cookie.Name = "Marketplace.Auth";
			options.Cookie.HttpOnly = true;
			options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
			options.Cookie.SameSite = SameSiteMode.Lax;

			options.ExpireTimeSpan = cookieSettings.ExpireTimeSpan;
			options.SlidingExpiration = cookieSettings.SlidingExpiration;

			options.Events.OnRedirectToLogin = context =>
			{
				context.Response.StatusCode = StatusCodes.Status401Unauthorized;
				return Task.CompletedTask;
			};

			options.Events.OnRedirectToAccessDenied = context =>
			{
				context.Response.StatusCode = StatusCodes.Status403Forbidden;
				return Task.CompletedTask;
			};
		};
	}
}
