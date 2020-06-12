namespace StreamCompanionTypes.Interfaces.Sources
{
    public interface ISettingsSource
    {
        string SettingGroup { get; }
        /// <summary>
        /// Free up resources used by UI object created in <see cref="GetUiSettings"/>
        /// </summary>
        void Free();
        object GetUiSettings();
    }
}
