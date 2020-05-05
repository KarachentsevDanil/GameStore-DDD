using GSP.Shared.Utils.Data.Account.Context.EntityMappings;
using GSP.Shared.Utils.Data.Context;
using GSP.Shared.Utils.Domain.Account.Entities;
using Microsoft.EntityFrameworkCore;

namespace GSP.Shared.Utils.Data.Account.Context
{
    public abstract class SharedAccountDbContext : GspDbContext
    {
        protected SharedAccountDbContext(DbContextOptions options)
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