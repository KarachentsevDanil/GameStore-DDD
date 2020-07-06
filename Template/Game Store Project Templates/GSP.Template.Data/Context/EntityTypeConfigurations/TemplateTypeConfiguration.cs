using GSP.Template.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static GSP.Template.Data.Context.Constants.DbColumnConstraintConstants;

namespace GSP.Template.Data.Context.EntityTypeConfigurations
{
    public class TemplateTypeConfiguration : IEntityTypeConfiguration<TemplateBase>
    {
        public void Configure(EntityTypeBuilder<TemplateBase> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).HasMaxLength(NameMaxLength).IsRequired();

            builder.HasQueryFilter(q => !q.IsDeleted);
        }
    }
}