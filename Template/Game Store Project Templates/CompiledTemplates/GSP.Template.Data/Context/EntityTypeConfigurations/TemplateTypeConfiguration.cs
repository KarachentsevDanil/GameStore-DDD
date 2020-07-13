using GSP.$projectPlainName$.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static $safeprojectname$.Context.Constants.DbColumnConstraintConstants;

namespace $safeprojectname$.Context.EntityTypeConfigurations
{
    public class $domainName$TypeConfiguration : IEntityTypeConfiguration<$domainName$Base>
    {
        public void Configure(EntityTypeBuilder<$domainName$Base> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).HasMaxLength(NameMaxLength).IsRequired();

            builder.HasQueryFilter(q => !q.IsDeleted);
        }
    }
}