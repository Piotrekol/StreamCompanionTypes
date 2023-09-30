namespace StreamCompanionTypes.Interfaces
{
    public interface IPluginMetadata
    {
        string Name { get; }
        string Description { get; }
        string Authors { get; }
        string ProjectURL { get; }
        string WikiUrl { get; }
    }
}
