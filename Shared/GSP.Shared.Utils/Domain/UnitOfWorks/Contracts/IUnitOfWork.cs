using System;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Domain.UnitOfWorks.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveAsync(CancellationToken ct);
    }
}