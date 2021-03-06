﻿using GSP.Shared.Utils.Common.EventBus.Base.Models;

namespace GSP.Rate.Application.CQS.Bus.Messages
{
    public class GameRatingUpdatedMessage : IntegrationEvent
    {
        public GameRatingUpdatedMessage(long gameId, int countOfReviews, double averageRating)
        {
            GameId = gameId;
            CountOfReviews = countOfReviews;
            AverageRating = averageRating;
        }

        public long GameId { get; set; }

        public int CountOfReviews { get; set; }

        public double AverageRating { get; set; }
    }
}