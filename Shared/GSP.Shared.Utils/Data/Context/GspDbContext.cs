using Microsoft.EntityFrameworkCore;

namespace GSP.Shared.Utils.Data.Context
{
    public abstract class GspDbContext : DbContext
    {
        protected GspDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}