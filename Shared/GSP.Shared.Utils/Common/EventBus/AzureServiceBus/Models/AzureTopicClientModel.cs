namespace GSP.Shared.Utils.Common.EventBus.AzureServiceBus.Models
{
    public class AzureTopicClientModel : BaseAzureClientModel
    {
        public AzureTopicClientModel(string topicName)
        {
            TopicName = topicName;
        }
    }
}