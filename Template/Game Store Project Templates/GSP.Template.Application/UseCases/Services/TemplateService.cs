using AutoMapper;
using GSP.Shared.Grid.Expressions.Contracts;
using GSP.Shared.Grid.Grids;
using GSP.Shared.Utils.Application.UseCases.Services;
using GSP.Shared.Utils.Data.Grid.Models;
using GSP.Shared.Utils.Domain.Repositories.Contracts;
using GSP.Template.Application.UseCases.DTOs.Templates;
using GSP.Template.Application.UseCases.Services.Contracts;
using GSP.Template.Domain.Entities;
using GSP.Template.Domain.UnitOfWorks.Contracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Template.Application.UseCases.Services
{
    public class TemplateService :
        BaseService<ITemplateUnitOfWork, TemplateBase, GetTemplateDto, AddTemplateDto, UpdateTemplateDto>,
        ITemplateService
    {
        private readonly IGridExpressionGenerator<TemplateBase> _templateGridExpressionGenerator;

        public TemplateService(
            ITemplateUnitOfWork unitOfWork,
            IBaseRepository<TemplateBase> repository,
            IMapper mapper,
            ILogger<TemplateBase> logger,
            IGridExpressionGenerator<TemplateBase> templateGridExpressionGenerator)
            : base(unitOfWork, repository, mapper, logger)
        {
            _templateGridExpressionGenerator = templateGridExpressionGenerator;
        }

        public async Task<GridModel> GetGridAsync(BaseGrid<TemplateBase> baseGrid, CancellationToken ct = default)
        {
            Logger.LogInformation("Get grid with Grid Parameters = {@GridParameters}", baseGrid);
            return await UnitOfWork.TemplateRepository.GetPagedListAsync(_templateGridExpressionGenerator, baseGrid, ct);
        }

        protected override TemplateBase MapEntity(AddTemplateDto addItemDto)
        {
            return new TemplateBase(addItemDto.Name);
        }

        protected override void UpdateEntity(UpdateTemplateDto updateItemDto, TemplateBase entity)
        {
            entity.Update(updateItemDto.Name);
        }
    }
}