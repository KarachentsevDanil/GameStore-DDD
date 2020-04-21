using GSP.Shared.Utils.Domain.Account.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GSP.Shared.Utils.Data.Account.Context.EntityMappings
{
    public class AccountTypeMappingConfiguration : IEntityTypeConfiguration<SharedAccount>
    {
        public void Configure(EntityTypeBuilder<SharedAccount> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedNever();

            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(255);

            builder.Property(p => p.LastName).IsRequired().HasMaxLength(255);

            builder.Property(p => p.Email).IsRequired().HasMaxLength(255);

            builder.HasQueryFilter(q => !q.IsDeleted);
        }
    }
}