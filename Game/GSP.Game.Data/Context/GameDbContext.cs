using GSP.Game.Data.Context.EntityMappings;
using GSP.Game.Domain.Entities;
using GSP.Shared.Utils.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GSP.Game.Data.Context
{
    public class GameDbContext : GspDbContext
    {
        public GameDbContext(DbContextOptions<GameDbContext> options)
            : base(options)
        {
        }

        public DbSet<GameBase> Games { get; set; }

        public DbSet<DeveloperStudio> DeveloperStudios { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DeveloperStudioTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GameTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GenreTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PublisherTypeConfiguration());
        }
    }
}