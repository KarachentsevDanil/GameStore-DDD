using GSP.Game.Data.Context;
using GSP.Game.Data.Repositories;
using GSP.Game.Domain.Repositories.Contracts;
using GSP.Game.Domain.UnitOfWorks.Contracts;
using GSP.Shared.Utils.Common.UserPrincipal.Contracts;
using GSP.Shared.Utils.Data.UnitOfWorks;
using MediatR;

namespace GSP.Game.Data.UnitOfWorks
{
    public class GameUnitOfWork : UnitOfWork<GameDbContext>, IGameUnitOfWork
    {
        private readonly GameDbContext _context;

        private IDeveloperStudioRepository _developerStudioRepository;

        private IGameRepository _gameRepository;

        private IGenreRepository _genreRepository;

        private IPublisherRepository _publisherRepository;

        public GameUnitOfWork(GameDbContext context, IMediator mediator, IGspUserPrincipal gspUserPrincipal)
            : base(context, mediator, gspUserPrincipal)
        {
            _context = context;
        }

        public IGameRepository GameRepository
        {
            get
            {
                return _gameRepository ??= new GameRepository(_context);
            }
        }

        public IGenreRepository GenreRepository
        {
            get
            {
                return _genreRepository ??= new GenreRepository(_context);
            }
        }

        public IPublisherRepository PublisherRepository
        {
            get
            {
                return _publisherRepository ??= new PublisherRepository(_context);
            }
        }

        public IDeveloperStudioRepository DeveloperStudioRepository
        {
            get
            {
                return _developerStudioRepository ??= new DeveloperStudioRepository(_context);
            }
        }
    }
}