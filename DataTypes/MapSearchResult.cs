using CollectionManager.Enums;
using System.Collections.Generic;
using StreamCompanionTypes.Enums;

namespace StreamCompanionTypes.DataTypes
{
    public class MapSearchResult
    {
        private readonly MapSearchArgs _searchArgs;
        public List<IBeatmap> BeatmapsFound { get { return _beatmapsFound; } set { } }
        readonly List<IBeatmap> _beatmapsFound = new List<IBeatmap>();
        public List<IOutputPattern> FormatedStrings = new List<IOutputPattern>();
        public bool FoundBeatmaps => _beatmapsFound.Count > 0;
        public string MapSearchString => _searchArgs.Raw;
        public IModsEx Mods = null;
        public OsuStatus Action => _searchArgs.Status;
        public PlayMode? PlayMode => _searchArgs.PlayMode;
        public string EventSource { get; set; }

        public MapSearchResult(MapSearchArgs searchArgs)
        {
            _searchArgs = searchArgs;
        }
    }
}
