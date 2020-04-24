using GSP.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GSP.Order.Data.Context.EntityMappings
{
    public class GameTypeConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.Name).HasMaxLength(255).IsRequired();

            builder.Property(t => t.Description).HasMaxLength(500).IsRequired();

            builder.Property(p => p.IconUri).HasConversion<string>().HasMaxLength(2048);

            builder.Property(p => p.PhotoUri).HasConversion<string>().HasMaxLength(2048);

            builder.HasQueryFilter(q => !q.IsDeleted);
        }
    }
}