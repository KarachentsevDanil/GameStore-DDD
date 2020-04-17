using GSP.Account.Data.Context.EntityMappings;
using GSP.Account.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GSP.Account.Data.Context
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> options)
            : base(options)
        {
        }

        public DbSet<AccountBase> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AccountEntityTypeConfiguration());
        }
    }
}