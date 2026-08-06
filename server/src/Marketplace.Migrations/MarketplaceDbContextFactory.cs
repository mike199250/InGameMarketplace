using Marketplace.Infrastructure.Database;
using Marketplace.Infrastructure.Database.EFCore;
using Marketplace.Shared.Configuration;
using Marketplace.Shared.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Marketplace.Migrations;

public class MarketplaceDbContextFactory : IDesignTimeDbContextFactory<MarketplaceDbContext>
{
	public MarketplaceDbContext CreateDbContext(string[] args)
	{
		var optionsBuilder = new DbContextOptionsBuilder<MarketplaceDbContext>();

		var serverPaths = new ServerPaths(Directory.GetCurrentDirectory());
		var configuration = new ConfigurationManager().AddMarketplaceConfiguration(serverPaths, isDevelopment: true);
		var settings = configuration.GetSection(nameof(DatabaseSettings)).Get<DatabaseSettings>();

		optionsBuilder.UseMarketplaceDatabase(settings!, npgsql =>
		{
			npgsql.MigrationsAssembly(typeof(MarketplaceDbContextFactory).Assembly.GetName().Name);
		});
		return new MarketplaceDbContext(optionsBuilder.Options);
	}
}
