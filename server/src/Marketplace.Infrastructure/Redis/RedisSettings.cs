namespace Marketplace.Infrastructure.Redis;

public record RedisSettings
{
	public required string Host { get; init; }

	public int Port { get; init; }

	public required string Password { get; init; }
}
