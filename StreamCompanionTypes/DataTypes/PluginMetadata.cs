using StreamCompanionTypes.Interfaces;

namespace StreamCompanionTypes.DataTypes
{
    public class PluginMetadata : IPluginMetadata
    {
        public string Name { get; }
        public string Description { get; }
        public string Authors { get; }
        public string ProjectURL { get; }
        public string WikiUrl { get; }

        public PluginMetadata(string name, string description, string authors, string projectURL, string wikiUrl = null)
        {
            Name = name;
            Description = description;
            Authors = authors;
            ProjectURL = projectURL;
            WikiUrl = wikiUrl;
        }
    }
}
