using Marketplace.Shared.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Marketplace.Shared.Configuration;

internal class ConfigurationConfigurator(ServerPaths serverPaths) : IHostApplicationBuilderConfigurator
{
	public void Configure(IHostApplicationBuilder builder)
	{
		LoadEnvLocalInDevelopment(builder.Environment);

		builder.Configuration
			.AddEnvironmentVariables()
			;
	}

	private void LoadEnvLocalInDevelopment(IHostEnvironment environment)
	{
		if (!environment.IsDevelopment())
		{
			return;
		}
		
		var localEnv = Path.Combine(serverPaths.ServerRoot, "env/.env.local");
		if (!File.Exists(localEnv))
		{
			return;
		}

		DotNetEnv.Env.Load(localEnv);
	}
}
