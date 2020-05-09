using System;

namespace GSP.WepApi.Aggregator.DTOs.Games
{
    public class GameDetailsDto
    {
        public string Name { get; set; }

        public double AverageRating { get; set; }

        public double OrderCounts { get; set; }

        public float Price { get; set; }

        public Uri IconUri { get; set; }

        public Uri PhotoUri { get; set; }
    }
}