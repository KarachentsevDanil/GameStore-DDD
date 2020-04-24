using GSP.Payment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GSP.Payment.Data.Context.EntityMappings
{
    public class PaymentMethodTypeConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.CardHolderFullName).HasMaxLength(2048).IsRequired();

            builder.Property(t => t.CardNumber).HasMaxLength(2048).IsRequired();

            builder.Property(t => t.Expiration).HasMaxLength(1024).IsRequired();

            builder.Property(t => t.Cvv).HasMaxLength(1024).IsRequired();

            builder.HasIndex(p => p.AccountId);

            builder.HasQueryFilter(q => !q.IsDeleted);
        }
    }
}