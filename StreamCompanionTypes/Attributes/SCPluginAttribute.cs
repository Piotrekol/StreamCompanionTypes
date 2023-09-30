using StreamCompanionTypes.Interfaces;
using System;

namespace StreamCompanionTypes.Attributes
{
    /// <summary>
    /// Basic information about a plugin 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class SCPluginAttribute : Attribute, IPluginMetadata
    {
        /// <summary>
        /// User readable name of this plugin
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Short-ish description of what this plugin does
        /// </summary>
        public string Description { get; }
        /// <summary>
        /// List of authors
        /// </summary>
        public string Authors { get; }
        /// <summary>
        /// Project url, most likely github repository link
        /// </summary>
        public string ProjectURL { get; }
        /// <summary>
        /// Url to a page with usage information
        /// </summary>
        public string WikiUrl { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"><inheritdoc cref="Name"/></param>
        /// <param name="description"><inheritdoc cref="Description"/></param>
        /// <param name="authors"><inheritdoc cref="Authors"/></param>
        /// <param name="projectURL"><inheritdoc cref="ProjectURL"/></param>
        /// <param name="wikiUrl"><inheritdoc cref="WikiUrl"/></param>
        public SCPluginAttribute(string name, string description, string authors, string projectURL, string wikiUrl = null)
        {
            Name = name;
            Description = description;
            Authors = authors;
            ProjectURL = projectURL;
            WikiUrl = wikiUrl;
        }
    }
}
