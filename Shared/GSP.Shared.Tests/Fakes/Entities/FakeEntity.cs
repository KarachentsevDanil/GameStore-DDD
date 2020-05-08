using GSP.Shared.Utils.Domain.Base;

namespace GSP.Shared.Tests.Fakes.Entities
{
    public class FakeEntity : BaseEntity
    {
        public FakeEntity(string name, string description)
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