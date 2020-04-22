using GSP.Order.Data.Context.EntityMappings;
using GSP.Order.Domain.Entities;
using GSP.Shared.Utils.Data.Account.Context;
using Microsoft.EntityFrameworkCore;

namespace GSP.Order.Data.Context
{
    public class OrderDbContext : SharedAccountDbContext<OrderDbContext>
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<OrderBase> Orders { get; set; }

        public DbSet<OrderGame> OrderGames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new OrderTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderGameTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GameTypeConfiguration());
        }
    }
}