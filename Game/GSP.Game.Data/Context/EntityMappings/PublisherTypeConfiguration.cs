using GSP.Game.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GSP.Game.Data.Context.EntityMappings
{
    public class PublisherTypeConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).HasMaxLength(255).IsRequired();

            builder.Property(p => p.Description).HasMaxLength(500).IsRequired();

            builder.Property(p => p.LogoUri).HasConversion<string>().HasMaxLength(2048).IsRequired();

            builder.Property(p => p.WebPageUri).HasConversion<string>().HasMaxLength(2048).IsRequired();

            builder.HasQueryFilter(q => !q.IsDeleted);
        }
    }
}