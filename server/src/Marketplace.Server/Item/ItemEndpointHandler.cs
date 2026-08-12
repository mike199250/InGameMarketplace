using Marketplace.Infrastructure.Database.EFCore;
using Marketplace.Infrastructure.Database.EFCore.Entities;
using Marketplace.Shared.Authentication;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Server.Item;

internal static class ItemEndpointHandler
{
	public static async Task<Ok<UserItem[]>> GetUserItems(
		ICurrentUser user,
		MarketplaceDbContext dbContext,
		CancellationToken cancellationToken)
	{
		var items = await dbContext.UserItems.AsNoTracking()
			.Where(x => x.OwnerId == user.UserId)
			.ToArrayAsync(cancellationToken);
		return TypedResults.Ok(items);
	}
}
