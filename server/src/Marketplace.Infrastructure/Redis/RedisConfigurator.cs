using Marketplace.Shared.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;

namespace Marketplace.Infrastructure.Redis;

internal class RedisConfigurator : IHostApplicationBuilderConfigurator
{
	public void Configure(IHostApplicationBuilder builder)
	{
		var settings = builder.Configuration.GetSection(nameof(RedisSettings)).Get<RedisSettings>()
			?? throw new InvalidOperationException($"Configuration section '{nameof(RedisSettings)}' is missing or invalid.");
		var connectionMultiplexer = Connect(settings);

		builder.Services.AddSingleton(connectionMultiplexer);
		builder.Properties[nameof(IConnectionMultiplexer)] = connectionMultiplexer;
	}

	private static IConnectionMultiplexer Connect(RedisSettings settings)
	{
		var config = new ConfigurationOptions
		{
			EndPoints =
				{
					$"{settings.Host}:{settings.Port}",
				},
			Password = settings.Password,
		};
		return ConnectionMultiplexer.Connect(config);
	}
}
