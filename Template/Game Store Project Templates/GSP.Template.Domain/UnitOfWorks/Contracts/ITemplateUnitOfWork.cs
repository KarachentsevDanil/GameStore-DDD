using GSP.Shared.Utils.Domain.UnitOfWorks.Contracts;
using GSP.Template.Domain.Repositories.Contracts;

namespace GSP.Template.Domain.UnitOfWorks.Contracts
{
    public interface ITemplateUnitOfWork : IUnitOfWork
    {
        ITemplateRepository TemplateRepository { get; }
    }
}