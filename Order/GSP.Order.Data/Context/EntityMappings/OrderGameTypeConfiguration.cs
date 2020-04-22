using GSP.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GSP.Order.Data.Context.EntityMappings
{
    public class OrderGameTypeConfiguration : IEntityTypeConfiguration<OrderGame>
    {
        public void Configure(EntityTypeBuilder<OrderGame> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasOne(p => p.Game)
                .WithMany()
                .HasForeignKey(p => p.GameId);

            builder.HasOne(p => p.Order)
                .WithMany(p => p.Games)
                .HasForeignKey(p => p.OrderId);
        }
    }
}