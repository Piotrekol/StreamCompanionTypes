using CollectionManager.Enums;
using System.Collections.Generic;
using StreamCompanionTypes.Enums;

namespace StreamCompanionTypes.DataTypes
{
    /// <summary>
    /// Event search results containing relevant event data (beatmap, current mods, playmode...)
    /// </summary>
    public class MapSearchResult
    {
        public readonly MapSearchArgs SearchArgs;
        public List<IBeatmap> BeatmapsFound { get { return _beatmapsFound; } set { } }
        readonly List<IBeatmap> _beatmapsFound = new List<IBeatmap>();
        public List<IOutputPattern> FormatedStrings = new List<IOutputPattern>();
        public bool FoundBeatmaps => _beatmapsFound.Count > 0;
        public string MapSearchString => SearchArgs.Raw;
        public IModsEx Mods = null;
        public OsuStatus Action => SearchArgs.Status;
        public PlayMode? PlayMode => SearchArgs.PlayMode;
        public string EventSource { get; set; }

        public MapSearchResult(MapSearchArgs searchArgs)
        {
            SearchArgs = searchArgs;
        }
    }
}
