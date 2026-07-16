namespace Marketplace.Infrastructure.Database;

internal record DatabaseSettings
{
	public required string Host { get; init; }

	public int Port { get; init; }

	public required string Database { get; init; }

	public required string Username { get; init; }

	public required string Password { get; init; }
}
