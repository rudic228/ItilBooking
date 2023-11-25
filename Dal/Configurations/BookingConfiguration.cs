using Dal.Entities;
using Dal.Enums;
using Dal.FluentApiCustom;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            builder.Property(x => x.BookingState)
                .HasMaxLengthOfMaxLength(new EnumToStringConverter<BookingState>())
                .HasConversion<string>();

            builder.HasEnumStringValuesCheckConstraint(x => x.BookingState, new EnumToStringConverter<BookingState>());
        }
    }
}
