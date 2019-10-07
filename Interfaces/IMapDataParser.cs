using System.Collections.Generic;
using StreamCompanionTypes.DataTypes;
using StreamCompanionTypes.Enums;

namespace StreamCompanionTypes.Interfaces
{
    public interface IMapDataParser
    {
        List<OutputPattern> GetFormatedPatterns(Tokens replacements,OsuStatus status);
    }
}