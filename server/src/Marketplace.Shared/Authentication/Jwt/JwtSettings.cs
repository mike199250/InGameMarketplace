namespace Marketplace.Shared.Authentication.Jwt;

public class JwtSettings
{
	public string Issuer { get; init; } = "";

	public string Audience { get; init; } = "";

	public TimeSpan Lifetime { get; init; }

	public string SigningKey { get; init; } = "";
}
