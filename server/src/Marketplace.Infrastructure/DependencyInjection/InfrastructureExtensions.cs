using Marketplace.Infrastructure.Database;
using Marketplace.Shared.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Marketplace.Infrastructure.DependencyInjection;

public static class InfrastructureExtensions
{
	public static IServiceCollection AddMarketplaceInfrastructure(this IServiceCollection services)
	{
		return services
			.AddSingleton<IHostApplicationBuilderConfigurator, DatabaseConfigurator>()
			;
	}
}
