using Marketplace.Shared.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Formatting.Compact;

namespace Marketplace.Shared.Logging;

internal class LoggingConfigurator : IHostApplicationBuilderConfigurator
{
	public void Configure(IHostApplicationBuilder builder)
	{
		builder.Services.AddSerilog((services, logger) =>
		{
			logger
				.ReadFrom.Configuration(builder.Configuration)
				.ReadFrom.Services(services)
				.Enrich.FromLogContext()
				;

			var environment = builder.Environment;
			if (environment.IsDevelopment())
			{
				var serverPaths = services.GetRequiredService<ServerPaths>();
				var logPath = Path.Combine(
					serverPaths.ServerRoot,
					"logs",
					environment.ApplicationName,
					".log");
				
				logger.WriteTo.File(
					new CompactJsonFormatter(),
					logPath,
					rollingInterval: RollingInterval.Day);
			}
		});
	}
}
