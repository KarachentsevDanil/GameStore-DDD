using GSP.Shared.Utils.Common.UserPrincipal.Contracts;
using GSP.Shared.Utils.Data.Context;
using GSP.Shared.Utils.Data.Extensions;
using GSP.Shared.Utils.Domain.UnitOfWorks.Contracts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Data.UnitOfWorks
{
    public class UnitOfWork<TContext> : IUnitOfWork
        where TContext : GspDbContext
    {
        public UnitOfWork(TContext context, IMediator mediator, IGspUserPrincipal userPrincipal)
        {
            Context = context;
            Mediator = mediator;

            Context.SetCurrentUserAccount(userPrincipal.User);
        }

        protected TContext Context { get; }

        protected IMediator Mediator { get; }

        public virtual async Task SaveAsync(CancellationToken ct)
        {
            await Context.SaveChangesAsync(ct);
            await Mediator.DispatchDomainEventsAsync(Context);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Context?.Dispose();
            }
        }
    }
}