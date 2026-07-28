using Marketplace.Shared.Authentication.Jwt;

namespace Marketplace.Shared.Authentication;

internal class AuthenticationSettings
{
	public CookieSettings? Cookie { get; set; }
	
	public JwtSettings? Jwt { get; set; }
}

internal class CookieSettings
{
	public TimeSpan ExpireTimeSpan { get; set; }

	public bool SlidingExpiration { get; set; }
}
