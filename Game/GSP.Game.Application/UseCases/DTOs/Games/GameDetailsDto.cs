using GSP.Game.Domain.Enums;
using System;

namespace GSP.Game.Application.UseCases.DTOs.Games
{
    public class GameDetailsDto
    {
        public string Name { get; set; }

        public double AverageRating { get; set; }

        public double OrderCounts { get; set; }

        public float Price { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public AgeRestrictionSystem AgeRestrictionSystem { get; set; }

        public Uri IconUri { get; set; }

        public Uri PhotoUri { get; set; }
    }
}