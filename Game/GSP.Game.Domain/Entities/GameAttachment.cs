using GSP.Game.Domain.Enums;
using GSP.Shared.Utils.Domain.Base;
using System;
using System.Collections.Generic;

namespace GSP.Game.Domain.Entities
{
    public class GameAttachment : ValueObject<GameAttachment>
    {
        private long _id;

        public GameAttachment(AttachmentType type, Uri linkUri, string description)
        {
            Type = type;
            Description = description;
            LinkUri = linkUri;
        }

        private GameAttachment()
        {
        }

        public AttachmentType Type { get; private set; }

        public Uri LinkUri { get; private set; }

        public string Description { get; private set; }

        public int GameId { get; private set; }

        public override GameAttachment CopyFrom(GameAttachment copyFromObject)
        {
            Type = copyFromObject.Type;
            LinkUri = copyFromObject.LinkUri;
            Description = copyFromObject.Description;

            return this;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Type;
            yield return Description;
            yield return LinkUri;
        }
    }
}