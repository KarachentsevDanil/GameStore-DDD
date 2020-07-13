using GSP.Shared.Utils.Data.Grid.Models;
using GSP.$projectPlainName$.Domain.Grids;
using MediatR;

namespace $safeprojectname$.CQS.Queries.$domainName$s
{
    public class Get$domainName$GridQuery : IRequest<GridModel>
    {
        public $domainName$Grid Grid { get; set; }
    }
}