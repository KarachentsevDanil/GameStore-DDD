using GSP.Shared.Utils.Common.Sessions.Contracts;
using GSP.Shared.Utils.Data.Context.Audit.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Data.Context
{
    public abstract class GspDbContext : DbContext
    {
        protected GspDbContext(DbContextOptions options, IGspSession session, IAuditService auditService)
            : base(options)
        {
            Session = session;
            AuditService = auditService;
        }

        public IGspSession Session { get; }

        protected IAuditService AuditService { get; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AuditService.AuditEntities(ChangeTracker);
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}