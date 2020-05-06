using GSP.Payment.Data.Context.EntityMappings;
using GSP.Payment.Domain.Entities;
using GSP.Shared.Utils.Common.Sessions.Contracts;
using GSP.Shared.Utils.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GSP.Payment.Data.Context
{
    public class PaymentDbContext : GspDbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options, IGspSession gspSession)
            : base(options, gspSession)
        {
        }

        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        public DbSet<PaymentHistory> PaymentHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PaymentHistoryTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentMethodTypeConfiguration());
        }
    }
}