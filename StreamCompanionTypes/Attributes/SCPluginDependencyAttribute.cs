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
        /// Case sensetive name of the plugin
        /// </summary>
        public string PluginName { get; }
        /// <summary>
        /// Minimum version required; major.minor[.build[.revision]] eg. 1.0.0
        /// </summary>
        public Version MinVersion { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pluginName"><inheritdoc cref="PluginName"/></param>
        /// <param name="minVersion"><inheritdoc cref="MinVersion"/></param>
        public SCPluginDependencyAttribute(string pluginName, string minVersion)
        {
            PluginName = pluginName;
            MinVersion = Version.Parse(minVersion);
        }
    }
}
