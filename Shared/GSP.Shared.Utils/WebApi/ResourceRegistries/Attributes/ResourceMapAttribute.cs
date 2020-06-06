using System;

namespace GSP.Shared.Utils.WebApi.ResourceRegistries.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ResourceMapAttribute : Attribute
    {
        public ResourceMapAttribute(string resourceName, string resourceValue)
        {
            ResourceName = resourceName;
            ResourceValue = resourceValue;
        }

        public string ResourceName { get; set; }

        public string ResourceValue { get; set; }
    }
}