using System;
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
        int MapId { get; set; }
        OsuStatus Status { get; set; }
        string SourceName { get; }
        string MapHash { get; set; }
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
        public int MapId { get; set; } = 0;
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