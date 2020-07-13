using GSP.Shared.Grid.Grids;
using GSP.Shared.Utils.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Data.Grid.Models;
using $safeprojectname$.UseCases.DTOs.$domainName$s;
using GSP.$projectPlainName$.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace $safeprojectname$.UseCases.Services.Contracts
{
    public interface I$domainName$Service : IBaseService<Get$domainName$Dto, Add$domainName$Dto, Update$domainName$Dto>
    {
        Task<GridModel> GetGridAsync(BaseGrid<$domainName$Base> baseGrid, CancellationToken ct = default);
    }
}