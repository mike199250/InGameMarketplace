using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Marketplace.Infrastructure.Database.EFCore.ValueConverters;

internal class DateTimeOffsetValueConverter : ValueConverter<DateTimeOffset, DateTimeOffset>
{
	public DateTimeOffsetValueConverter()
		: base
		(
			// Must convert to UTC when saving to DB
			toDb => toDb.ToUniversalTime(),
			// Reading from DB gives the DB timezone,
			// even if we call .ToUniversalTime() here
			fromDb => fromDb)
	{
	}
}
