using GSP.Game.Domain.Repositories.Contracts;
using GSP.Shared.Utils.Domain.UnitOfWorks.Contracts;

namespace GSP.Game.Domain.UnitOfWorks.Contracts
{
    public interface IGameUnitOfWork : IUnitOfWork
    {
        IGameRepository GameRepository { get; }

        IGenreRepository GenreRepository { get; }

        IPublisherRepository PublisherRepository { get; }

        IDeveloperStudioRepository DeveloperStudioRepository { get; }
    }
}