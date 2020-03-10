namespace StreamCompanionTypes.Interfaces.Services
{
    public interface IContextAwareLogger : ILogger
    {
        void SetContextData(string key, string value);
    }
}