using Marketplace.Shared.Routing;

namespace Marketplace.Shared.Identity;

public static class IdentityRoutes
{
	private const string IdentityPrefix = RoutePrefixes.ApiV1 + "/identity";
	private const string InternalIdentityPrefix = RoutePrefixes.InternalApiV1 + "/identity";

	public static class Logout
	{
		public const string Cookie = IdentityPrefix + "/logout/cookie";
	}

	public static class Refresh
	{
		public const string Token = IdentityPrefix + "/refresh/token";
	}

	public static class Internal
	{
		public static class DirectLogin
		{
			public const string Cookie = InternalIdentityPrefix + "/login/direct/cookie";
			public const string Token = InternalIdentityPrefix + "/login/direct/token";
		}
	}
}
