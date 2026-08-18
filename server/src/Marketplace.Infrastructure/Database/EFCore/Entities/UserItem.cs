namespace Marketplace.Infrastructure.Database.EFCore.Entities;

public class UserItem
{
	public Guid Id { get; set; }
	public Guid OwnerId { get; set; }

	public int ItemId { get; set; }
	public int Quantity { get; set; }
}
