using GSP.Shared.Utils.Data.Repositories;
using GSP.Template.Data.Context;
using GSP.Template.Domain.Entities;
using GSP.Template.Domain.Repositories.Contracts;

namespace GSP.Template.Data.Repositories
{
    public class TemplateRepository : BaseRepository<TemplateDbContext, TemplateBase>, ITemplateRepository
    {
        public TemplateRepository(TemplateDbContext context)
            : base(context)
        {
        }
    }
}