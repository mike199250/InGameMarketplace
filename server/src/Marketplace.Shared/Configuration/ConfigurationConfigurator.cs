using Marketplace.Shared.Hosting;
using Microsoft.Extensions.Hosting;

namespace Marketplace.Shared.Configuration;

internal class ConfigurationConfigurator(ServerPaths serverPaths) : IHostApplicationBuilderConfigurator
{
	public void Configure(IHostApplicationBuilder builder)
	{
		builder.Configuration.AddMarketplaceConfiguration(serverPaths, builder.Environment.IsDevelopment());
	}
}
