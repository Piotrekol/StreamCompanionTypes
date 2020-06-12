namespace StreamCompanionTypes.Interfaces.Services
{
    public interface ISaver
    {
        string SaveDirectory { get; set; }
        void Save(string fileName, string content);
    }
}
