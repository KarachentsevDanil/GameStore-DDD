using GSP.Shared.Utils.Common.Date.Contracts;
using GSP.Shared.Utils.Common.Sessions.Contracts;
using GSP.Shared.Utils.Common.Sessions.Models;
using GSP.Shared.Utils.Data.Context.Audit.Contracts;
using GSP.Shared.Utils.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace GSP.Shared.Utils.Data.Context.Audit
{
    public class AuditService : IAuditService
    {
        private readonly ILogger _logger;

        private readonly IDateTimeService _dateTimeService;

        private readonly IGspSession _gspSession;

        public AuditService(ILogger<AuditService> logger, IDateTimeService dateTimeService, IGspSession gspSession)
        {
            _logger = logger;
            _dateTimeService = dateTimeService;
            _gspSession = gspSession;
        }

        public void AuditEntities(ChangeTracker changeTracker)
        {
            _logger.LogInformation("Audit have started");

            var userInfo = _gspSession.GetUserAccountOrDefault();

            if (userInfo == null)
            {
                return;
            }

            var auditableEntities = changeTracker
                .Entries<AuditableEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified)
                .ToList();

            var currentDate = _dateTimeService.UtcNow;

            foreach (var auditableEntity in auditableEntities)
            {
                ProcessAuditableEntity(auditableEntity, userInfo, currentDate);
            }
        }

        private void ProcessAuditableEntity(EntityEntry<AuditableEntity> auditableEntity, GspUserAccountModel userAccountModel, DateTime currentDate)
        {
            if (auditableEntity.State == EntityState.Added)
            {
                auditableEntity.Entity.SetCreatedInfo(userAccountModel.Id, currentDate);
            }
            else
            {
                auditableEntity.Entity.SetUpdatedInfo(userAccountModel.Id, currentDate);
            }
        }
    }
}