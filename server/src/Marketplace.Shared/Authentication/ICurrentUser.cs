using Microsoft.AspNetCore.Http;
using System.Security.Authentication;
using System.Security.Claims;

namespace Marketplace.Shared.Authentication;

public interface ICurrentUser
{
	Guid UserId { get; }
}

internal sealed class CurrentUser : ICurrentUser
{
	public Guid UserId { get; }

	public CurrentUser(IHttpContextAccessor accessor)
	{
		var value = accessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

		if (!Guid.TryParse(value, out var userId))
		{
			throw new AuthenticationException("Missing or invalid NameIdentifier claim.");
		}

		UserId = userId;
	}
}
