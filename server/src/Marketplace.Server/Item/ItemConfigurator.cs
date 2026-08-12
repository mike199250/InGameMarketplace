using Marketplace.Shared.Hosting;

namespace Marketplace.Server.Item;

internal class ItemConfigurator : IWebApplicationConfigurator
{
	public void Configure(WebApplication app)
	{
		app.MapGet(ItemRoutes.GetUserItems, ItemEndpointHandler.GetUserItems)
			.RequireAuthorization();

		app.MapPost(ItemRoutes.Internal.TestCreateUserItems, ItemEndpointHandler.TestCreateUserItems)
			.RequireAuthorization();
	}
}
