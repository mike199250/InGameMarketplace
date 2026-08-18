using Marketplace.Shared.Routing;

namespace Marketplace.Server.Item;

public static class ItemRoutes
{
	public const string GetUserItems = RoutePrefixes.ApiV1 + "/items";

	public static class Internal
	{
		public const string TestCreateUserItems = RoutePrefixes.InternalApiV1 + "/items/test-create";
	}
}
