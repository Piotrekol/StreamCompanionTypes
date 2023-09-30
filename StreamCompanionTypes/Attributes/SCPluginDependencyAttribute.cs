using System;

namespace StreamCompanionTypes.Attributes
{
    /// <summary>
    /// Require another plugin to be present in order to load
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class SCPluginDependencyAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pluginName">Case sensetive name of the plugin</param>
        /// <param name="semVerVersion">major.minor[.build[.revision]] eg. 1.0.0</param>
        public SCPluginDependencyAttribute(string pluginName, string minVersion)
        {
            PluginName = pluginName;
            MinVersion = Version.Parse(minVersion);
        }

        public string PluginName { get; }
        public Version MinVersion { get; }
    }
}
