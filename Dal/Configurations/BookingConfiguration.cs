using Dal.EfExtensions;
using Dal.Entities;
using Dal.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dal.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public virtual void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Bookings");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.BeginBookingDate)
                .HasColumnType("date");

            builder.Property(x => x.EndBookingDate)
                .HasColumnType("date");

            builder.Property(x => x.Price)
                .HasPrecision(16, 2);

            builder.HasPositiveCheckConstraint(x => x.Price);

            builder.Property(x => x.BookingState)
                .HasConversion(new EnumToStringConverter<BookingState>());

            builder.HasEnumStringValuesCheckConstraint(x => x.BookingState, new EnumToStringConverter<BookingState>());
        }
    }
}
