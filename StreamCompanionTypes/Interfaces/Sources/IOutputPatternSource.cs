using System.Collections.Generic;
using System.Threading.Tasks;
using StreamCompanionTypes.DataTypes;
using StreamCompanionTypes.Enums;

namespace StreamCompanionTypes.Interfaces.Sources
{
    public interface IOutputPatternSource
    {
        Task<List<IOutputPattern>> GetOutputPatterns(IMapSearchResult map, Tokens tokens, OsuStatus status);
    }
}