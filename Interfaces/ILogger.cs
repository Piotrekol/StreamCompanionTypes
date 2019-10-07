using StreamCompanionTypes.Enums;

namespace StreamCompanionTypes.Interfaces
{
    public interface ILogger
    {
        void Log(object logMessage, LogLevel loglvevel, params string[] vals);
    }
}
