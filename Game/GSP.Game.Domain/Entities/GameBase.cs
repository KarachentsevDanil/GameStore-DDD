using GSP.Game.Domain.Entities.ValueObjects;
using GSP.Game.Domain.Events;
using GSP.Shared.Utils.Domain.Base;
using System.Collections.Generic;

namespace GSP.Game.Domain.Entities
{
    public class GameBase : AuditableEntity
    {
        private readonly List<GameAttachment> _attachments = new List<GameAttachment>();

        public GameBase(long genreId, long developerStudioId, long publisherId, GameDetails details)
        {
            GameDetails = details;
            DeveloperStudioId = developerStudioId;
            PublisherId = publisherId;
            GenreId = genreId;
        }

        private GameBase()
        {
        }

        public GameDetails GameDetails { get; private set; }

        public long GenreId { get; private set; }

        public Genre Genre { get; private set; }

        public long DeveloperStudioId { get; private set; }

        public DeveloperStudio DeveloperStudio { get; private set; }

        public long PublisherId { get; private set; }

        public Publisher Publisher { get; private set; }

        public IReadOnlyCollection<GameAttachment> Attachments => _attachments;

        public void Update(long genreId, long developerStudioId, long publisherId)
        {
            DeveloperStudioId = developerStudioId;
            PublisherId = publisherId;
            GenreId = genreId;

            GameUpdatedEvent gameUpdated = new GameUpdatedEvent
            {
                Id = Id,
                GenreId = genreId,
                Price = GameDetails.Price,
                Description = GameDetails.Description,
                AverageRating = GameDetails.AverageRating,
                Name = GameDetails.Name,
                ReleaseDate = GameDetails.ReleaseDate,
                AgeRestrictionSystem = GameDetails.AgeRestrictionSystem,
                IconUri = GameDetails.IconUri,
                PhotoUri = GameDetails.PhotoUri,
                ReviewCount = GameDetails.ReviewCount,
                OrderCount = GameDetails.OrderCount
            };

            DomainEvents.Add(gameUpdated);
        }

        public void AddAttachments(List<GameAttachment> attachments)
        {
            attachments.ForEach(attachment => _attachments.Add(attachment));
        }
    }
}