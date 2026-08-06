using Marketplace.Shared.Hosting;
using Microsoft.Extensions.Configuration;

namespace Marketplace.Shared.Configuration;

public static class ConfigurationManagerExtensions
{
	public static IConfigurationManager AddMarketplaceConfiguration(this IConfigurationManager configuration, ServerPaths serverPaths, bool isDevelopment)
	{
		if (isDevelopment)
		{
			LoadEnvLocalInDevelopment(serverPaths);
		}

		configuration
			.AddJsonFile(Path.Combine(serverPaths.ServerRoot, "configs/appsettings.shared.json"), optional: true)
			.AddJsonFile(Path.Combine(serverPaths.ServerRoot, "secrets/secrets.json"), optional: true)
			.AddEnvironmentVariables()
			;
		return configuration;
	}

	private  static void LoadEnvLocalInDevelopment(ServerPaths serverPaths)
	{
		var localEnv = Path.Combine(serverPaths.ServerRoot, "env/.env.local");
		if (!File.Exists(localEnv))
		{
			return;
		}

		DotNetEnv.Env.Load(localEnv);
	}
}
