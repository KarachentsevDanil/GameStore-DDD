using GSP.Game.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GSP.Game.Data.Context.EntityMappings
{
    public class GenreTypeConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).HasMaxLength(255).IsRequired();

            builder.Property(p => p.Description).HasMaxLength(500).IsRequired();

            builder.HasQueryFilter(q => !q.IsDeleted);
        }
    }
}