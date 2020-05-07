using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GSP.Shared.Utils.Data.Context.Audit.Contracts
{
    public interface IAuditService
    {
        void AuditEntities(ChangeTracker changeTracker);
    }
}