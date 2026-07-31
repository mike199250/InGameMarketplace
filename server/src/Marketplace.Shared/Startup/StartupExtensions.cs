using Marketplace.Shared.Authentication;
using Marketplace.Shared.Configuration;
using Marketplace.Shared.Hosting;
using Marketplace.Shared.Identity;
using Marketplace.Shared.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace Marketplace.Shared.Startup;

public static class StartupExtensions
{
	public static IServiceCollection AddMarketplaceStartup(this IServiceCollection services)
	{
		return services
			.AddSingleton<ServerPaths>()
			.AddSingleton<IHostApplicationBuilderConfigurator, ConfigurationConfigurator>()
			.AddSingleton<IHostApplicationBuilderConfigurator, LoggingConfigurator>()
			.AddSingleton<IHostApplicationBuilderConfigurator, ExceptionHandlingConfigurator>()
			.AddSingleton<IWebApplicationConfigurator, ExceptionHandlingConfigurator>()
			;
	}

	public static IServiceCollection AddMarketplaceAuthentication(this IServiceCollection services)
	{
		return services
			.AddSingleton<IHostApplicationBuilderConfigurator, AuthenticationConfigurator>()
			.AddSingleton<IWebApplicationConfigurator, AuthenticationConfigurator>()
			;
	}

	public static IServiceCollection AddMarketplaceIdentity(this IServiceCollection services)
	{
		return services
			.AddSingleton<IWebApplicationConfigurator, IdentityConfigurator>()
			;
	}
}
