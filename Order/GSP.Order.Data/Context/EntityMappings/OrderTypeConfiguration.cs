using GSP.Order.Domain.Entities;
using GSP.Order.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GSP.Order.Data.Context.EntityMappings
{
    public class OrderTypeConfiguration : IEntityTypeConfiguration<OrderBase>
    {
        public void Configure(EntityTypeBuilder<OrderBase> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.OrderStatus).HasDefaultValue(OrderStatus.New).HasConversion<string>().HasMaxLength(50);

            builder.HasOne(p => p.Account)
                .WithMany()
                .HasForeignKey(p => p.AccountId);
        }
    }
}