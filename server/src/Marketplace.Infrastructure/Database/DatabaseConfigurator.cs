using Marketplace.Infrastructure.Database.EFCore;
using Marketplace.Shared.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
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

		builder.Services.AddDbContext<MarketplaceDbContext>((sp, options) =>
		{
			var settings = sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
			options.UseMarketplaceDatabase(settings);
		});
	}
}
