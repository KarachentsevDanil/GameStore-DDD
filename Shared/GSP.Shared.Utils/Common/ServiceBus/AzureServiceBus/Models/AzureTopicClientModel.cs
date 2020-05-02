namespace GSP.Shared.Utils.Common.ServiceBus.AzureServiceBus.Models
{
    public class AzureTopicClientModel : BaseAzureClientModel
    {
        public AzureTopicClientModel(string topicName)
        {
            TopicName = topicName;
        }
    }
}