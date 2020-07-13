using GSP.Shared.Utils.Application.CQS.Queries;
using $safeprojectname$.UseCases.DTOs.$domainName$s;

namespace $safeprojectname$.CQS.Queries.$domainName$s
{
    public class Get$domainName$ByIdQuery : BaseGetByIdQuery<Get$domainName$Dto>
    {
        public Get$domainName$ByIdQuery(long id)
        {
            Id = id;
        }

        public Get$domainName$ByIdQuery()
        {
        }
    }
}