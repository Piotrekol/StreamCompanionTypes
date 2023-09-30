using StreamCompanionTypes.Enums;

namespace StreamCompanionTypes.Interfaces.Services
{
    /// <summary>
    /// Generic logger
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Send message to configured log sinks
        /// </summary>
        /// <param name="logMessage">message template or exception</param>
        /// <param name="loglvevel">log level</param>
        /// <param name="vals">values to use in message template</param>
        void Log(object logMessage, LogLevel loglvevel, params string[] vals);
    }
}
