using Marketplace.Shared.Hosting;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;

namespace Marketplace.Infrastructure.DataProtection;

internal class DataProtectionConfigurator : IHostApplicationBuilderConfigurator
{
	public void Configure(IHostApplicationBuilder builder)
	{
		var connectionMultiplexer = (IConnectionMultiplexer)builder.Properties[nameof(IConnectionMultiplexer)];

		builder.Services.AddDataProtection()
			.PersistKeysToStackExchangeRedis(connectionMultiplexer)
			;
	}
}
