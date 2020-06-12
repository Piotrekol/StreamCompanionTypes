using System;
using CollectionManager.Enums;
using StreamCompanionTypes.Enums;
using StreamCompanionTypes.Interfaces;
using StreamCompanionTypes.Interfaces.Sources;

namespace StreamCompanionTypes.DataTypes
{
    /// <summary>
    /// Search arguments used by <see cref="IOsuEventSource"/>s to initiate new events
    /// </summary>
    public class MapSearchArgs : EventArgs
    {
        public string Artist { get; set; } = "";
        public string Title { get; set; } = "";
        public string Diff { get; set; } = "";
        public string Raw { get; set; } = "";
        public int MapId { get; set; } = 0;
        public OsuStatus Status { get; set; } = OsuStatus.Null;
        public string SourceName { get; }
        public string MapHash { get; set; }
        //TODO: enforce explicitly setting event type via ctor
        public OsuEventType EventType { get; set; } = OsuEventType.MapChange;

        public PlayMode? PlayMode { get; set; } = null;

        public MapSearchArgs(string sourceName)
        {
            SourceName = sourceName;
        }
    }
}