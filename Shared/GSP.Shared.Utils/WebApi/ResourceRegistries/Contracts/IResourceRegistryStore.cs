namespace GSP.Shared.Utils.WebApi.ResourceRegistries.Contracts
{
    public interface IResourceRegistryStore
    {
        string GetResourceValue(string resourceType);

        TResource GetResource<TResource>(string resourceType, string resourceValue)
            where TResource : class, IResource;
    }
}