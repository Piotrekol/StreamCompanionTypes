namespace StreamCompanionTypes.Interfaces
{
    public interface ISettingsProvider
    {
        string SettingGroup { get; }
        void Free();
        object GetUiSettings();
    }
}
