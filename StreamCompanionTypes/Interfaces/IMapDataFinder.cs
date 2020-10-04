using StreamCompanionTypes.DataTypes;
using StreamCompanionTypes.Enums;

namespace StreamCompanionTypes.Interfaces
{
    public interface IMapDataFinder
    {
        IMapSearchResult FindBeatmap(IMapSearchArgs searchArgs);
        OsuStatus SearchModes { get; }
        string SearcherName { get; }
        int Priority { get; set; }
    }
}