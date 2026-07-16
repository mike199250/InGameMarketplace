using Marketplace.Shared.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;

namespace Marketplace.Infrastructure.Database;

internal class DatabaseConfigurator : IHostApplicationBuilderConfigurator
{
	public void Configure(IHostApplicationBuilder builder)
	{
		builder.Services.AddOptions<DatabaseSettings>()
			.BindConfiguration(nameof(DatabaseSettings))
			.ValidateDataAnnotations()
			.ValidateOnStart()
			;
	}

	private static string GetConnectionString(DatabaseSettings settings)
	{
		return new NpgsqlConnectionStringBuilder
		{
			Host = settings.Host,
			Port = settings.Port,
			Database = settings.Database,
			Username = settings.Username,
			Password = settings.Password,
		}.ConnectionString;
	}
}
