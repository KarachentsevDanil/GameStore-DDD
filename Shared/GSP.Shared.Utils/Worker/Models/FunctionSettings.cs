namespace GSP.Shared.Utils.Worker.Models
{
    public class FunctionSettings
    {
        public FunctionSettings(bool isDebug)
        {
            IsDebug = isDebug;
        }

        public bool IsDebug { get; }
    }
}