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
        private readonly TContext _context;

        private readonly IMediator _mediator;

        public UnitOfWork(TContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public virtual async Task SaveAsync(CancellationToken ct)
        {
            await _context.SaveChangesAsync(ct);
            await _mediator.DispatchDomainEventsAsync(_context);
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
                _context?.Dispose();
            }
        }
    }
}