using Marketplace.Infrastructure.Database.EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrastructure.Database.EFCore;

public class MarketplaceDbContext(DbContextOptions<MarketplaceDbContext> options) : DbContext(options)
{
	public DbSet<UserItem> UserItems => Set<UserItem>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(MarketplaceDbContext).Assembly);
	}
}
