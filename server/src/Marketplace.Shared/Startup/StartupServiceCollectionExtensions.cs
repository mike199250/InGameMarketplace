using Marketplace.Shared.Configuration;
using Marketplace.Shared.Hosting;
using Marketplace.Shared.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace Marketplace.Shared.Startup;

public static class StartupServiceCollectionExtensions
{
	public static IServiceCollection AddMarketplaceStartup(this IServiceCollection services)
	{
		return services
			.AddSingleton<ServerPaths>()
			.AddSingleton<IHostApplicationBuilderConfigurator, ConfigurationConfigurator>()
			.AddSingleton<IHostApplicationBuilderConfigurator, LoggingConfigurator>()
			;
	}
}
