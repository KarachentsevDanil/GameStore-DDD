using AutoMapper;
using GSP.Shared.Grid.Expressions.Contracts;
using GSP.Shared.Grid.Grids;
using GSP.Shared.Utils.Application.UseCases.Services;
using GSP.Shared.Utils.Data.Grid.Models;
using GSP.Shared.Utils.Domain.Repositories.Contracts;
using $safeprojectname$.UseCases.DTOs.$domainName$s;
using $safeprojectname$.UseCases.Services.Contracts;
using GSP.$projectPlainName$.Domain.Entities;
using GSP.$projectPlainName$.Domain.UnitOfWorks.Contracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace $safeprojectname$.UseCases.Services
{
    public class $domainName$Service :
        BaseService<I$domainName$UnitOfWork, $domainName$Base, Get$domainName$Dto, Add$domainName$Dto, Update$domainName$Dto>,
        I$domainName$Service
    {
        private readonly IGridExpressionGenerator<$domainName$Base> _$domainNameLowerTitleCase$GridExpressionGenerator;

        public $domainName$Service(
            I$domainName$UnitOfWork unitOfWork,
            IBaseRepository<$domainName$Base> repository,
            IMapper mapper,
            ILogger<$domainName$Base> logger,
            IGridExpressionGenerator<$domainName$Base> $domainNameLowerTitleCase$GridExpressionGenerator)
            : base(unitOfWork, repository, mapper, logger)
        {
            _$domainNameLowerTitleCase$GridExpressionGenerator = $domainNameLowerTitleCase$GridExpressionGenerator;
        }

        public async Task<GridModel> GetGridAsync(BaseGrid<$domainName$Base> baseGrid, CancellationToken ct = default)
        {
            Logger.LogInformation("Get grid with Grid Parameters = {@GridParameters}", baseGrid);
            return await UnitOfWork.$domainName$Repository.GetPagedListAsync(_$domainNameLowerTitleCase$GridExpressionGenerator, baseGrid, ct);
        }

        protected override $domainName$Base MapEntity(Add$domainName$Dto addItemDto)
        {
            return new $domainName$Base(addItemDto.Name);
        }

        protected override void UpdateEntity(Update$domainName$Dto updateItemDto, $domainName$Base entity)
        {
            entity.Update(updateItemDto.Name);
        }
    }
}