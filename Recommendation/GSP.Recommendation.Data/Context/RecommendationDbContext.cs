using GSP.Recommendation.Data.Context.EntityMappings;
using GSP.Recommendation.Domain.Entities;
using GSP.Shared.Utils.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GSP.Recommendation.Data.Context
{
    public class RecommendationDbContext : GspDbContext
    {
        public RecommendationDbContext(DbContextOptions<RecommendationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CompletedOrder> Orders { get; set; }

        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GameTypeConfiguration());
        }
    }
}