using GSP.Shared.Utils.Data.Extensions;
using GSP.Shared.Utils.Domain.UnitOfWorks.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Data.UnitOfWorks
{
    public class UnitOfWork<TContext> : IUnitOfWork
        where TContext : DbContext
    {
        public UnitOfWork(TContext context, IMediator mediator)
        {
            Context = context;
            Mediator = mediator;
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