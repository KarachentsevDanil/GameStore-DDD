using GSP.Shared.Utils.Application.CQS.Commands;
using $safeprojectname$.UseCases.DTOs.$domainName$s;

namespace $safeprojectname$.CQS.Commands.$domainName$s
{
    public class Update$domainName$Command : BaseUpdateItemCommand<Get$domainName$Dto>
    {
        public string Name { get; set; }
    }
}