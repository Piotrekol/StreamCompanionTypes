using System.Threading;
using System.Threading.Tasks;
using StreamCompanionTypes.DataTypes;
using StreamCompanionTypes.Enums;

namespace StreamCompanionTypes.Interfaces
{
    public interface IMapDataFinder
    {
        Task<IMapSearchResult> FindBeatmap(IMapSearchArgs searchArgs, CancellationToken cancellationToken);
        OsuStatus SearchModes { get; }
        string SearcherName { get; }
        int Priority { get; set; }
    }
}