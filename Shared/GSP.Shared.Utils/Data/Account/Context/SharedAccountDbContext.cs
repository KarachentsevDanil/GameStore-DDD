using GSP.Shared.Utils.Data.Account.Context.EntityMappings;
using GSP.Shared.Utils.Domain.Account.Entities;
using Microsoft.EntityFrameworkCore;

namespace GSP.Shared.Utils.Data.Account.Context
{
    public abstract class SharedAccountDbContext<TContext> : DbContext
        where TContext : DbContext
    {
        protected SharedAccountDbContext(DbContextOptions<TContext> options)
            : base(options)
        {
        }

        public DbSet<SharedAccount> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountTypeMappingConfiguration());
        }
    }
}