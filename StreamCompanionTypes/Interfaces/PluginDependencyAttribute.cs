using System;

namespace StreamCompanionTypes.Interfaces
{
    public class PluginDependencyAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pluginName">Case sensetive name of the plugin</param>
        /// <param name="semVerVersion">major.minor[.build[.revision]] eg. 1.0.0</param>
        public PluginDependencyAttribute(string pluginName, string minVersion)
        {
            PluginName = pluginName;
            MinVersion = Version.Parse(minVersion);
        }

        public string PluginName { get; }
        public Version MinVersion { get; }
    }
}
