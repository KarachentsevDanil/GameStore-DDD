namespace GSP.Recommendation.Worker.Constants
{
    public static class AzureServiceBusConstants
    {
        public const string GameTopicName = "game";

        public const string GameOrdersCountUpdatedSubscription = "Recommendation_GameOrdersCount";

        public const string GameRatingUpdatedSubscription = "Recommendation_GameRatingUpdated";
    }
}