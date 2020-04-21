using GSP.Rate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GSP.Rate.Data.Context.EntityMappings
{
    public class RateTypeMappingConfiguration : IEntityTypeConfiguration<RateBase>
    {
        public void Configure(EntityTypeBuilder<RateBase> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Comment).IsRequired().HasMaxLength(500);

            builder.HasOne(p => p.Account)
                .WithMany()
                .HasForeignKey(k => k.AccountId);

            builder.HasIndex(i => i.GameId);

            builder.HasQueryFilter(q => !q.IsDeleted);
        }
    }
}