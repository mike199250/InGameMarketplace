using Marketplace.Shared.Authentication;
using Marketplace.Shared.Configuration;
using Marketplace.Shared.Hosting;
using Marketplace.Shared.Identity;
using Marketplace.Shared.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace Marketplace.Shared.Startup;

public static class StartupExtensions
{
	public static IServiceCollection AddMarketplaceDefaults(this IServiceCollection services)
	{
		var exceptionHandlingConfigurator = new ExceptionHandlingConfigurator();
		return services
			.AddSingleton<ServerPaths>()
			.AddSingleton<IHostApplicationBuilderConfigurator, ConfigurationConfigurator>()
			.AddSingleton<IHostApplicationBuilderConfigurator, LoggingConfigurator>()
			.AddSingleton<IHostApplicationBuilderConfigurator>(exceptionHandlingConfigurator)
			.AddSingleton<IWebApplicationConfigurator>(exceptionHandlingConfigurator)
			;
	}

	public static IServiceCollection AddMarketplaceAuthentication(this IServiceCollection services)
	{
		var authenticationConfigurator = new AuthenticationConfigurator();
		return services
			.AddSingleton<IHostApplicationBuilderConfigurator>(authenticationConfigurator)
			.AddSingleton<IWebApplicationConfigurator>(authenticationConfigurator)
			;
	}

	public static IServiceCollection AddMarketplaceIdentity(this IServiceCollection services)
	{
		return services
			.AddSingleton<IWebApplicationConfigurator, IdentityConfigurator>()
			;
	}
}
