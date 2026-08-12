using Marketplace.Shared.Hosting;

namespace Marketplace.Server.Item;

internal static class ItemServiceCollectionExtensions
{
	public static IServiceCollection AddMarketplaceItem(this IServiceCollection services)
	{
		return services.AddSingleton<IWebApplicationConfigurator, ItemConfigurator>();
	}
}
