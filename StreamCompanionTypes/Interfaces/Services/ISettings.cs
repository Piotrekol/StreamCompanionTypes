using System;
using System.Collections.Generic;
using StreamCompanionTypes.DataTypes;

namespace StreamCompanionTypes.Interfaces.Services
{
    public interface ISettings
    {
        EventHandler<SettingUpdated> SettingUpdated { get; set; }
        string FullConfigFilePath { get; }
        T Get<T>(ConfigEntry entry);
        void Add<T>(string key, T value, bool raiseUpdate = false);
        [Obsolete("Use json arrays instead")]
        void Add<T>(string key, List<T> valueList, bool raiseUpdate = false);
        string GetRaw(string key, string defaultValue = "");
        [Obsolete("Use json arrays instead")]
        List<string> Get(string key);
        [Obsolete("Use json arrays instead")]
        List<int> Geti(string key);
        bool Delete(ConfigEntry entry);
        bool Delete(string key);
        void Save();
        void Load();
    }
}