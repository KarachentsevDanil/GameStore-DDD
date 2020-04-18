using GSP.Shared.Utils.Domain.Base;
using System.Collections.Generic;

namespace GSP.Game.Domain.Entities
{
    public class GameBase : BaseEntity
    {
        public GameBase(int genreId, int developerStudioId, int publisherId, GameDetails details)
        {
            GameDetails = details;
            DeveloperStudioId = developerStudioId;
            PublisherId = publisherId;
            GenreId = genreId;
            Attachments = new List<GameAttachment>();
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

        public ICollection<GameAttachment> Attachments { get; private set; }

        public void Update(int genreId, int developerStudioId, int publisherId)
        {
            DeveloperStudioId = developerStudioId;
            PublisherId = publisherId;
            GenreId = genreId;
        }

        public void AddAttachments(List<GameAttachment> attachments)
        {
            attachments.ForEach(attachment => Attachments.Add(attachment));
        }
    }
}