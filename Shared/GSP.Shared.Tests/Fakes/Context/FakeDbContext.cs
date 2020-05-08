using GSP.Shared.Tests.Fakes.Entities;
using GSP.Shared.Utils.Common.Sessions.Contracts;
using GSP.Shared.Utils.Data.Context;
using GSP.Shared.Utils.Data.Context.Audit.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GSP.Shared.Tests.Fakes.Context
{
    public class FakeDbContext : GspDbContext
    {
        public FakeDbContext(DbContextOptions options, IGspSession session, IAuditService auditService)
            : base(options, session, auditService)
        {
        }

        public DbSet<FakeEntity> FakeEntities { get; set; }

        public DbSet<FakeAuditableEntity> FakeAuditableEntities { get; set; }
    }
}