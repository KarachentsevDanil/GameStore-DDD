using GSP.Shared.Utils.Data.Repositories;
using $safeprojectname$.Context;
using GSP.$projectPlainName$.Domain.Entities;
using GSP.$projectPlainName$.Domain.Repositories.Contracts;

namespace $safeprojectname$.Repositories
{
    public class $domainName$Repository : BaseRepository<$domainName$DbContext, $domainName$Base>, I$domainName$Repository
    {
        public $domainName$Repository($domainName$DbContext context)
            : base(context)
        {
        }
    }
}