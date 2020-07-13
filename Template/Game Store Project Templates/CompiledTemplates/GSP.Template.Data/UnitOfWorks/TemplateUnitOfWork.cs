using GSP.Shared.Utils.Data.UnitOfWorks;
using $safeprojectname$.Context;
using $safeprojectname$.Repositories;
using GSP.$projectPlainName$.Domain.Repositories.Contracts;
using GSP.$projectPlainName$.Domain.UnitOfWorks.Contracts;
using MediatR;

namespace $safeprojectname$.UnitOfWorks
{
    public class $domainName$UnitOfWork : UnitOfWork<$domainName$DbContext>, I$domainName$UnitOfWork
    {
        private I$domainName$Repository _$domainNameLowerTitleCase$Repository;

        public $domainName$UnitOfWork($domainName$DbContext context, IMediator mediator)
            : base(context, mediator)
        {
        }

        public I$domainName$Repository $domainName$Repository
        {
            get
            {
                return _$domainNameLowerTitleCase$Repository ??= new $domainName$Repository(Context);
            }
        }
    }
}