using GSP.Rate.Data.Context.EntityMappings;
using GSP.Rate.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GSP.Rate.Data.Context
{
    public class RateDbContext : DbContext
    {
        public RateDbContext(DbContextOptions<RateDbContext> options)
            : base(options)
        {
        }

        public DbSet<RateBase> Rates { get; set; }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RateTypeMappingConfiguration());
            modelBuilder.ApplyConfiguration(new AccountTypeMappingConfiguration());
        }
    }
}