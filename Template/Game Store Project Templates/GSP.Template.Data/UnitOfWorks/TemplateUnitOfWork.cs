using GSP.Shared.Utils.Data.UnitOfWorks;
using GSP.Template.Data.Context;
using GSP.Template.Data.Repositories;
using GSP.Template.Domain.Repositories.Contracts;
using GSP.Template.Domain.UnitOfWorks.Contracts;
using MediatR;

namespace GSP.Template.Data.UnitOfWorks
{
    public class TemplateUnitOfWork : UnitOfWork<TemplateDbContext>, ITemplateUnitOfWork
    {
        private ITemplateRepository _templateRepository;

        public TemplateUnitOfWork(TemplateDbContext context, IMediator mediator)
            : base(context, mediator)
        {
        }

        public ITemplateRepository TemplateRepository
        {
            get
            {
                return _templateRepository ??= new TemplateRepository(Context);
            }
        }
    }
}