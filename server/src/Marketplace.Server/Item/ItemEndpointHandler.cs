using Marketplace.Infrastructure.Database.EFCore;
using Marketplace.Infrastructure.Database.EFCore.Entities;
using Marketplace.Server.Item.Payloads;
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

	public static async Task<Ok> TestCreateUserItems(
		IReadOnlyList<TestCreateUserItemRequest> requests,
		ICurrentUser user,
		MarketplaceDbContext dbContext,
		CancellationToken cancellationToken)
	{
		var newItems = requests.Select(request => new UserItem
		{
			Id = Guid.CreateVersion7(),
			OwnerId = user.UserId,
			ItemId = request.ItemId,
			Quantity = request.Quantity,
		});
		
		await dbContext.AddRangeAsync(newItems, cancellationToken);
		await dbContext.SaveChangesAsync(cancellationToken);

		return TypedResults.Ok();
	}
}
