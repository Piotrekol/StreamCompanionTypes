using System.Collections.Generic;
using StreamCompanionTypes.DataTypes;
using StreamCompanionTypes.Enums;

namespace StreamCompanionTypes.Interfaces
{
    public interface IMapDataParser
    {
        List<IOutputPattern> GetFormatedPatterns(Tokens replacements,OsuStatus status);
    }
}