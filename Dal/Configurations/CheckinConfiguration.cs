using Dal.EfExtensions;
using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            builder.HasPositiveCheckConstraint(x => x.Price);
        }
    }
}
