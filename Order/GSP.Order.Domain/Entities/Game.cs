using GSP.Shared.Utils.Domain.Base;
using System;

namespace GSP.Order.Domain.Entities
{
    public class Game : BaseEntity
    {
        public Game(long id, string name, string description, float price, Uri photo, Uri logo)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            PhotoUri = photo;
            IconUri = logo;
        }

        private Game()
        {
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public float Price { get; private set; }

        public Uri PhotoUri { get; private set; }

        public Uri IconUri { get; private set; }
    }
}