using GSP.Shared.Utils.Common.Sessions.Contracts;
using GSP.Shared.Utils.Data.Context;
using GSP.Shared.Utils.Data.Context.Audit.Contracts;
using GSP.Template.Data.Context.EntityTypeConfigurations;
using GSP.Template.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GSP.Template.Data.Context
{
    public class TemplateDbContext : GspDbContext
    {
        public TemplateDbContext(DbContextOptions options, IGspSession session, IAuditService auditService)
            : base(options, session, auditService)
        {
        }

        public DbSet<TemplateBase> Templates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TemplateTypeConfiguration());
        }
    }
}