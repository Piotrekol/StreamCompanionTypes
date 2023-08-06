using System;
using System.Collections.Generic;
using StreamCompanionTypes.DataTypes;

namespace StreamCompanionTypes.Interfaces.Services
{
    public interface ISettings
    {
        IReadOnlyDictionary<string, object> SettingEntries { get; }
        EventHandler<SettingUpdated> SettingUpdated { get; set; }
        string FullConfigFilePath { get; }
        T Get<T>(ConfigEntry entry);
        T Get<T>(string key, T defaultValue);
        void Add<T>(string key, T value, bool raiseUpdate = false);
        void Add<T>(ConfigEntry entry, T value, bool raiseUpdate = false);
        bool Delete(ConfigEntry entry);
        bool Delete(string key);
        void Save();
        void Load();
    }
}