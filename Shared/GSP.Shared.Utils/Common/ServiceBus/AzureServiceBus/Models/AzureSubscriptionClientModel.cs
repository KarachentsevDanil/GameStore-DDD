namespace GSP.Shared.Utils.Common.ServiceBus.AzureServiceBus.Models
{
    public class AzureSubscriptionClientModel : BaseAzureClientModel
    {
        public AzureSubscriptionClientModel(string topicName, string subscriptionName)
        {
            TopicName = topicName;
            SubscriptionName = subscriptionName;
        }

        public AzureSubscriptionClientModel()
        {
        }

        public string SubscriptionName { get; set; }
    }
}