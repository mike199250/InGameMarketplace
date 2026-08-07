using Marketplace.Infrastructure.Database.EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marketplace.Infrastructure.Database.EFCore.EntityConfigurations;

public sealed class UserItemEntityConfiguration : IEntityTypeConfiguration<UserItem>
{
	public void Configure(EntityTypeBuilder<UserItem> builder)
	{
		builder.ToTable(nameof(UserItem));

		builder.HasKey(x => x.Id);

		builder.Property(x => x.Id)
			.ValueGeneratedNever();

		builder.Property(x => x.OwnerId)
			.IsRequired();

		builder.Property(x => x.ItemId)
			.IsRequired();

		builder.Property(x => x.Quantity)
			.IsRequired();

		builder.HasIndex(x => new { x.OwnerId, x.ItemId });
	}
}
