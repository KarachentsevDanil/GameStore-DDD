using GSP.Shared.Utils.Application.CQS.Commands;
using $safeprojectname$.UseCases.DTOs.$domainName$s;

namespace $safeprojectname$.CQS.Commands.$domainName$s
{
    public class Add$domainName$Command : BaseCreateItemCommand<Get$domainName$Dto>
    {
        public string Name { get; set; }
    }
}