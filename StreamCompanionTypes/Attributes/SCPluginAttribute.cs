using System;

namespace StreamCompanionTypes.Interfaces
{
    /// <summary>
    /// Basic information about a plugin 
    /// </summary>
    public class SCPluginAttribute : Attribute, IPluginMetadata
    {
        public string Name { get; }
        public string Description { get; }
        public string Authors { get; }
        public string ProjectURL { get; }
        public string WikiUrl { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">User readable name of your plugin</param>
        /// <param name="description">Short-ish description of what your plugin does</param>
        /// <param name="authors">List of authors</param>
        /// <param name="projectURL">Project url(most likely github repository link)</param>
        /// <param name="wikiUrl">Url to a page with usage information</param>
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
