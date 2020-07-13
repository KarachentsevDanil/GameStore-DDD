using GSP.Shared.Utils.Common.Sessions.Contracts;
using GSP.Shared.Utils.Data.Context;
using GSP.Shared.Utils.Data.Context.Audit.Contracts;
using $safeprojectname$.Context.EntityTypeConfigurations;
using GSP.$projectPlainName$.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace $safeprojectname$.Context
{
    public class $domainName$DbContext : GspDbContext
    {
        public $domainName$DbContext(DbContextOptions options, IGspSession session, IAuditService auditService)
            : base(options, session, auditService)
        {
        }

        public DbSet<$domainName$Base> $domainName$s { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new $domainName$TypeConfiguration());
        }
    }
}