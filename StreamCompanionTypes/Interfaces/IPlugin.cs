namespace StreamCompanionTypes.Interfaces
{
    /// <summary>
    /// Marker inferface which defines a class that should get initialized in StreamCompanion <para/>
    /// Remember to also add [<see cref="SCPluginAttribute"/>()] on your class with required information <para/>
    /// All dependencies defined in plugin class constructor will get injected.
    /// </summary>
    public interface IPlugin 
    {
        
    }
}