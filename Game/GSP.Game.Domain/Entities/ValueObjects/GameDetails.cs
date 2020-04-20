using GSP.Game.Domain.Enums;
using GSP.Shared.Utils.Domain.Base;
using System;
using System.Collections.Generic;

namespace GSP.Game.Domain.Entities.ValueObjects
{
    public class GameDetails : ValueObject<GameDetails>
    {
        public GameDetails(string name, float price, string description, DateTime releaseDate, AgeRestrictionSystem restrictionSystem)
        {
            Name = name;
            Price = price;
            Description = description;
            ReleaseDate = releaseDate;
            AgeRestrictionSystem = restrictionSystem;
        }

        private GameDetails()
        {
        }

        public string Name { get; private set; }

        public double AverageRating { get; private set; }

        public int ReviewCount { get; private set; }

        public int OrderCount { get; private set; }

        public float Price { get; private set; }

        public string Description { get; private set; }

        public DateTime ReleaseDate { get; private set; }

        public AgeRestrictionSystem AgeRestrictionSystem { get; private set; }

        public Uri IconUri { get; private set; }

        public Uri PhotoUri { get; private set; }

        public void UpdateGameDetails(string name, float price, string description, DateTime releaseDate, AgeRestrictionSystem restrictionSystem)
        {
            Name = name;
            Price = price;
            Description = description;
            ReleaseDate = releaseDate;
            AgeRestrictionSystem = restrictionSystem;
        }

        public void SetIcon(Uri icon)
        {
            IconUri = icon;
        }

        public void SetPhoto(Uri photo)
        {
            PhotoUri = photo;
        }

        public void UpdateRating(double rating, int count)
        {
            AverageRating = rating;
            ReviewCount = count;
        }

        public void UpdateOrderCount(int count)
        {
            OrderCount = count;
        }

        public override GameDetails CopyFrom(GameDetails copyFromObject)
        {
            Description = copyFromObject.Description;
            ReleaseDate = copyFromObject.ReleaseDate;
            AgeRestrictionSystem = copyFromObject.AgeRestrictionSystem;

            return this;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return AgeRestrictionSystem;
            yield return Description;
            yield return ReleaseDate;
        }
    }
}