using GSP.Recommendation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GSP.Recommendation.Data.Context.EntityMappings
{
    public class OrderTypeConfiguration : IEntityTypeConfiguration<CompletedOrder>
    {
        public void Configure(EntityTypeBuilder<CompletedOrder> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedNever();

            builder.HasIndex(p => p.AccountId);

            builder.OwnsMany(
                p => p.Games,
                gameBuilder =>
                {
                    gameBuilder.ToTable("OrderGames");

                    gameBuilder.HasKey(p => p.Id);

                    gameBuilder.WithOwner().HasForeignKey(t => t.OrderId);

                    gameBuilder.HasOne<Game>().WithMany().HasForeignKey(t => t.GameId);
                });

            builder.HasQueryFilter(q => !q.IsDeleted);
        }
    }
}
