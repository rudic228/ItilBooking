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

            builder.Property(x => x.Category)
                .HasMaxLengthOfMaxLength(new EnumToStringConverter<RoomCategory>())
                .HasConversion<string>();

            builder.HasEnumStringValuesCheckConstraint(x => x.Category, new EnumToStringConverter<RoomCategory>());
        }
    }
}
