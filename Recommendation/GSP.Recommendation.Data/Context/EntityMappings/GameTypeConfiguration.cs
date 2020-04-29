using GSP.Recommendation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GSP.Recommendation.Data.Context.EntityMappings
{
    public class GameTypeConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedNever();

            builder.HasIndex(p => p.GenreId);

            builder.HasIndex(p => p.CountOfOrders);

            builder.HasIndex(p => p.CountOfReviews);

            builder.HasIndex(p => p.AverageRating);

            builder.HasQueryFilter(q => !q.IsDeleted);
        }
    }
}