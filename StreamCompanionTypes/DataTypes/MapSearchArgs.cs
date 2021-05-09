using System;
using CollectionManager.DataTypes;
using CollectionManager.Enums;
using StreamCompanionTypes.Enums;
using StreamCompanionTypes.Interfaces.Sources;

namespace StreamCompanionTypes.DataTypes
{
    public interface IMapSearchArgs
    {
        string Artist { get; set; }
        string Title { get; set; }
        string Diff { get; set; }
        string Raw { get; set; }
        string OsuFilePath { get; set; }
        int MapId { get; set; }
        string MapHash { get; set; }
        Mods Mods { get; set; }
        OsuStatus Status { get; set; }
        string SourceName { get; }
        OsuEventType EventType { get; set; }
        PlayMode? PlayMode { get; set; }
    }

    /// <summary>
    /// Search arguments used by <see cref="IOsuEventSource"/>s to initiate new events
    /// </summary>
    public class MapSearchArgs : EventArgs, IMapSearchArgs
    {
        public string Artist { get; set; } = "";
        public string Title { get; set; } = "";
        public string Diff { get; set; } = "";
        public string Raw { get; set; } = "";
        public string OsuFilePath { get; set; } = null;
        public int MapId { get; set; } = 0;
        public Mods Mods { get; set; } = Mods.Omod;
        public OsuStatus Status { get; set; } = OsuStatus.Null;
        public string SourceName { get; }
        public string MapHash { get; set; }
        public OsuEventType EventType { get; set; }
        public PlayMode? PlayMode { get; set; } = null;

        public MapSearchArgs(string sourceName, OsuEventType eventType)
        {
            SourceName = sourceName;
            EventType = eventType;
        }
    }
}