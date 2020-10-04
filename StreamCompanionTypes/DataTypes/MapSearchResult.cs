using CollectionManager.Enums;
using System.Collections.Generic;
using System.Linq;
using StreamCompanionTypes.Enums;

namespace StreamCompanionTypes.DataTypes
{

    /// <summary>
    /// Event search results containing relevant event data (beatmap, current mods, playmode...)
    /// </summary>
    public interface IMapSearchResult
    {
        IMapSearchArgs SearchArgs { get; }
        List<IBeatmap> BeatmapsFound { get; }
        List<IOutputPattern> OutputPatterns { get; }
        string MapSearchString { get; }
        OsuStatus Action { get; }
        PlayMode? PlayMode { get; }
        string MapSource { get; set; }
    }

    /// <summary>
    /// <inheritdoc cref="IMapSearchResult"/>
    /// </summary>
    public class MapSearchResult : IMapSearchResult
    {
        public IMapSearchArgs SearchArgs { get; }
        public List<IBeatmap> BeatmapsFound { get; } = new List<IBeatmap>();
        public List<IOutputPattern> OutputPatterns { get; } = new List<IOutputPattern>();
        public IModsEx Mods = null;

        public string MapSearchString => SearchArgs.Raw;
        public OsuStatus Action => SearchArgs.Status;
        public PlayMode? PlayMode => SearchArgs.PlayMode;
        public string MapSource { get; set; }

        public MapSearchResult(IMapSearchArgs searchArgs)
        {
            SearchArgs = searchArgs;
        }
    }
}
