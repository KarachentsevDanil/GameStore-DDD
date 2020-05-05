namespace GSP.Order.Application.CQS.Bus.Constants
{
    public static class OrderServiceBusConstants
    {
        public const string GameTopicName = "game";

        public const string GameOrderCountUpdatedLabel = "GameOrderCountUpdated";

        public const string OrderTopicName = "order";

        public const string OrderCompletedLabel = "OrderCompleted";
    }
}