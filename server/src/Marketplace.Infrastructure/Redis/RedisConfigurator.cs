using Marketplace.Shared.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace Marketplace.Infrastructure.Redis;

internal class RedisConfigurator : IHostApplicationBuilderConfigurator
{
	public void Configure(IHostApplicationBuilder builder)
	{
		builder.Services.AddOptions<RedisSettings>()
			.BindConfiguration(nameof(RedisSettings))
			.ValidateDataAnnotations()
			.ValidateOnStart()
			;

		builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
		{
			var settings = sp.GetRequiredService<IOptions<RedisSettings>>().Value;
			var config = new ConfigurationOptions
			{
				EndPoints =
				{
					$"{settings.Host}:{settings.Port}",
				},
				Password = settings.Password,
			};
			return ConnectionMultiplexer.Connect(config);
		});
	}
}
