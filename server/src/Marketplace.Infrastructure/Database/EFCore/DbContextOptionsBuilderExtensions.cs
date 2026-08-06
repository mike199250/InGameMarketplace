using Microsoft.EntityFrameworkCore;
using Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace Marketplace.Infrastructure.Database.EFCore;

public static class DbContextOptionsBuilderExtensions
{
	public static DbContextOptionsBuilder UseMarketplaceDatabase(this DbContextOptionsBuilder options,
		DatabaseSettings settings,
		Action<NpgsqlDbContextOptionsBuilder>? configure = null)
	{
		return options.UseNpgsql(GetConnectionString(settings), npgsql =>
		{
			configure?.Invoke(npgsql);
		});
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
