using GSP.Shared.Grid.Grids;
using GSP.Shared.Utils.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Data.Grid.Models;
using GSP.Template.Application.UseCases.DTOs.Templates;
using GSP.Template.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Template.Application.UseCases.Services.Contracts
{
    public interface ITemplateService : IBaseService<GetTemplateDto, AddTemplateDto, UpdateTemplateDto>
    {
        Task<GridModel> GetGridAsync(BaseGrid<TemplateBase> baseGrid, CancellationToken ct = default);
    }
}