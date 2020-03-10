using System.Collections.Generic;
using StreamCompanionTypes.DataTypes;
using StreamCompanionTypes.Enums;

namespace StreamCompanionTypes.Interfaces
{
    public interface IOutputPatternGenerator
    {
        List<IOutputPattern> GetOutputPatterns(Tokens tokens, OsuStatus status);
    }
}