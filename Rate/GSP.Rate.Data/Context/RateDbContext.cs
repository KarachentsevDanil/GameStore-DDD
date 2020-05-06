using GSP.Rate.Data.Context.EntityMappings;
using GSP.Rate.Domain.Entities;
using GSP.Shared.Utils.Common.Sessions.Contracts;
using GSP.Shared.Utils.Data.Account.Context;
using Microsoft.EntityFrameworkCore;

namespace GSP.Rate.Data.Context
{
    public class RateDbContext : SharedAccountDbContext
    {
        public RateDbContext(DbContextOptions<RateDbContext> options, IGspSession gspSession)
            : base(options, gspSession)
        {
        }

        public DbSet<RateBase> Rates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RateTypeMappingConfiguration());
        }
    }
}