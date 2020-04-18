using GSP.Shared.Utils.Domain.Base;

namespace GSP.Game.Domain.Entities
{
    public class Genre : BaseEntity
    {
        public Genre(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public void Update(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}