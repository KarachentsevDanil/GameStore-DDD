namespace GSP.Order.Worker.Constants
{
    public static class AzureServiceBusConstants
    {
        public const string AccountTopicName = "account";

        public const string AccountCreatedSubscription = "Order_AccountCreated";

        public const string AccountUpdatedSubscription = "Order_AccountUpdated";

        public const string GameTopicName = "game";

        public const string GameCreatedSubscription = "Order_GameCreated";

        public const string GameUpdatedSubscription = "Order_GameUpdated";
    }
}