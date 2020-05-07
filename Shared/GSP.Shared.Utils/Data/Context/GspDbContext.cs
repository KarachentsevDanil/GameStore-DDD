using GSP.Shared.Utils.Common.Sessions.Contracts;
using GSP.Shared.Utils.Common.Sessions.Models;
using GSP.Shared.Utils.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Data.Context
{
    public abstract class GspDbContext : DbContext
    {
        protected GspDbContext(DbContextOptions options, IGspSession session)
            : base(options)
        {
            Session = session;
        }

        protected IGspSession Session { get; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ProcessAuditableEntities();
            return base.SaveChangesAsync(cancellationToken);
        }

        protected virtual void ProcessAuditableEntities()
        {
            var userInfo = Session.GetUserAccountOrDefault();

            if (userInfo == null)
            {
                return;
            }

            var auditableEntities = ChangeTracker
                .Entries<AuditableEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified)
                .ToList();

            foreach (var auditableEntity in auditableEntities)
            {
                ProcessAuditableEntity(auditableEntity, userInfo);
            }
        }

        private void ProcessAuditableEntity(EntityEntry<AuditableEntity> auditableEntity, GspUserAccountModel userAccountModel)
        {
            if (auditableEntity.State == EntityState.Added)
            {
                auditableEntity.Entity.SetCreatedInfo(userAccountModel.Id);
            }
            else
            {
                auditableEntity.Entity.SetUpdatedInfo(userAccountModel.Id);
            }
        }
    }
}