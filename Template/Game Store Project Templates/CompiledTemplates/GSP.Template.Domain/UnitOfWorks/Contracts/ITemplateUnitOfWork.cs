using GSP.Shared.Utils.Domain.UnitOfWorks.Contracts;
using $safeprojectname$.Repositories.Contracts;

namespace $safeprojectname$.UnitOfWorks.Contracts
{
    public interface I$domainName$UnitOfWork : IUnitOfWork
    {
        I$domainName$Repository $domainName$Repository { get; }
    }
}