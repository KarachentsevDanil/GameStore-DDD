namespace GSP.Shared.Utils.Common.Sessions.Models
{
    public class GspRequestInfoModel
    {
        public GspRequestInfoModel(string clientIp, string clientAgent)
        {
            ClientIp = clientIp;
            ClientAgent = clientAgent;
        }

        public string ClientIp { get; set; }

        public string ClientAgent { get; set; }
    }
}