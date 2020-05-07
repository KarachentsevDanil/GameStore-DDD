using GSP.Account.Domain.Entities;
using GSP.Account.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GSP.Account.Data.Context.EntityMappings
{
    public class AccountEntityTypeConfiguration : IEntityTypeConfiguration<AccountBase>
    {
        public void Configure(EntityTypeBuilder<AccountBase> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Email).HasMaxLength(255).IsRequired();

            builder.Property(p => p.FirstName).HasMaxLength(255).IsRequired();

            builder.Property(p => p.LastName).HasMaxLength(255).IsRequired();

            builder.Property(p => p.Role).HasDefaultValue(RoleType.User).HasConversion<string>().HasMaxLength(255).IsRequired();

            builder.Property(p => p.HashedPassword).HasMaxLength(2048).IsRequired();

            builder.HasQueryFilter(q => !q.IsDeleted);
        }
    }
}