using Dal.EfExtensions;
using Dal.Entities;
using Dal.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dal.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public virtual void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Rooms");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Area)
                .HasPrecision(4, 2);

            builder.Property(x => x.Price)
                .HasPrecision(16, 2);

            builder.HasPositiveCheckConstraint(x => x.Price);

            builder.Property(x => x.Category)
                .HasConversion<EnumToStringConverter<RoomCategory>>();

            builder.HasEnumStringValuesCheckConstraint(x => x.Category, new EnumToStringConverter<RoomCategory>());
        }
    }
}
