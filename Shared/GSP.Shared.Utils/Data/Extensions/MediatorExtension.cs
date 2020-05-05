using GSP.Shared.Utils.Data.Context;
using GSP.Shared.Utils.Domain.Base;
using MediatR;
using System.Linq;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Data.Extensions
{
    public static class MediatorExtension
    {
        public static async Task DispatchDomainEventsAsync<TContext>(this IMediator mediator, TContext ctx)
            where TContext : GspDbContext
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<BaseEntity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any())
                .ToList();

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.DomainEvents.Clear());

            var tasks = domainEvents
                .Select(domainEvent => mediator.Publish(domainEvent)).ToList();

            await Task.WhenAll(tasks);
        }
    }
}