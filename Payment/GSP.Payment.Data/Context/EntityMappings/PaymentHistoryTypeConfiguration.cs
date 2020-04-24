using GSP.Payment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GSP.Payment.Data.Context.EntityMappings
{
    public class PaymentHistoryTypeConfiguration : IEntityTypeConfiguration<PaymentHistory>
    {
        public void Configure(EntityTypeBuilder<PaymentHistory> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasIndex(p => p.AccountId);

            builder.HasIndex(p => p.PaymentMethodId);

            builder.HasIndex(p => p.OrderId);

            builder.HasQueryFilter(q => !q.IsDeleted);
        }
    }
}