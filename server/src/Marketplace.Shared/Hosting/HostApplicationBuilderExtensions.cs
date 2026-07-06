using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Marketplace.Shared.Hosting;

public static class HostApplicationBuilderExtensions
{
	public static IHostApplicationBuilder ApplyConfigurators(this IHostApplicationBuilder builder)
	{
		using var serviceProvider = builder.Services.BuildServiceProvider();

		var configurators = serviceProvider.GetServices<IHostApplicationBuilderConfigurator>();
		foreach (var configurator in configurators)
		{
			configurator.Configure(builder);
		}

		return builder;
	}
}
