namespace StreamCompanionTypes.Interfaces.Services
{
    public interface ISaver
    {
        /// <summary>
        /// Full path to directory where any plugin files should be saved in
        /// </summary>
        string SaveDirectory { get; }
        void Save(string fileName, string content);
    }
}
