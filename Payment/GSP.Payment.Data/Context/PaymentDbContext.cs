using GSP.Payment.Data.Context.EntityMappings;
using GSP.Payment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GSP.Payment.Data.Context
{
    public class PaymentDbContext : DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options)
            : base(options)
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