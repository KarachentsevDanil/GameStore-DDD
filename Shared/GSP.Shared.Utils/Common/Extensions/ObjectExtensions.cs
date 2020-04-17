using Newtonsoft.Json;

namespace GSP.Shared.Utils.Common.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToJsonString(this object item)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            return JsonConvert.SerializeObject(item, settings);
        }
    }
}