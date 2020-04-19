using GSP.Shared.Utils.Domain.Base;
using System;

namespace GSP.Game.Domain.Entities
{
    public class DeveloperStudio : BaseEntity
    {
        public DeveloperStudio(string name, string description, Uri logoUri, Uri webPageUri)
        {
            Name = name;
            Description = description;
            WebPageUri = webPageUri;
            LogoUri = logoUri;
        }

        private DeveloperStudio()
        {
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public Uri LogoUri { get; private set; }

        public Uri WebPageUri { get; private set; }

        public void Update(string name, string description, Uri logoUri, Uri webPageUri)
        {
            Name = name;
            Description = description;
            LogoUri = logoUri;
            WebPageUri = webPageUri;
        }
    }
}