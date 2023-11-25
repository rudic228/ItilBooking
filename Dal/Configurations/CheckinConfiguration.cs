using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Configurations
{
    public class CheckinConfiguration : IEntityTypeConfiguration<Checkin>
    {
        public virtual void Configure(EntityTypeBuilder<Checkin> builder)
        {
            builder.ToTable("Checkins");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.BeginCheckinDate)
                .HasColumnType("date");

            builder.Property(x => x.EndCheckinDate)
                .HasColumnType("date");

            builder.Property(x => x.Price)
                .HasPrecision(16, 2);

        }
    }
}
